    using Microsoft.Maps.MapControl.WPF;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Media;
    public static class BingMapsKiller
    {
        public static void Kill(Map map)
        {
            try
            {
                TypeDescriptor.Refresh(map);
                map.Dispose();
                var configType = typeof(Microsoft.Maps.MapControl.WPF.Core.MapConfiguration);
                var configuration = configType.GetField("configuration", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).GetValue(null);
                var requestQueue = configuration.GetFieldValue("requestQueue");
                var values = (System.Collections.IEnumerable)requestQueue.GetPropertyValue("Values");
                foreach (System.Collections.IEnumerable requests in values)
                    foreach (var request in requests.OfType<object>().ToList())
                    {
                        var target = request.GetPropertyValue("Callback").GetPropertyValue("Target");
                        if (target == map)
                            requests.ExecuteMethod("Remove", request);
                        else if (target is DependencyObject)
                        {
                            var d = (DependencyObject)target;
                            if (d.HasParentOf(map))
                                requests.ExecuteMethod("Remove", request);
                        }
                    }
            }
            catch { }
        }
        private static Object GetFieldValue(this Object obj, String fieldName)
        {
            var type = obj.GetType();
            return type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(obj);
        }
        private static Object GetPropertyValue(this Object obj, String fieldName)
        {
            var type = obj.GetType();
            return type.GetProperty(fieldName, BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | BindingFlags.Instance).GetValue(obj);
        }
        private static Object ExecuteMethod(this Object obj, String methodName, params object[] parameters)
        {
            var type = obj.GetType();
            return type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Invoke(obj, parameters);
        }
        private static Boolean HasParentOf(this DependencyObject obj, DependencyObject parent)
        {
            if (obj == null)
                return false;
            if (obj == parent)
                return true;
            return VisualTreeHelper.GetParent(obj).HasParentOf(parent);
        }
    }
