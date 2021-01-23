    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.Reflection;
    namespace extanfjTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                OrderType ouo = new OrderType(DateTime.Now);
                SetProperty(ouo);
                XmlSerializer ser = new XmlSerializer(typeof(OrderType));
                FileStream fs = new FileStream("C:/Projects/group.xml", FileMode.Create);
                ser.Serialize(fs, ouo);
                fs.Close();
            }
    
            public static void SetProperty(object _object)
            {
                if (_object == null)
                { return; }
                foreach (PropertyInfo prop in _object.GetType().GetProperties())
                {
                    if ("SemlerServices.OIOUBL.dll" != prop.PropertyType.Module.Name)
                    { continue; }
                    if (prop.PropertyType.IsArray)
                    {
                        var instance = Activator.CreateInstance(prop.PropertyType.GetElementType());
                        Array _array = Array.CreateInstance(prop.PropertyType.GetElementType(), 1);
                        _array.SetValue(instance, 0);
                        prop.SetValue(_object, _array, null);
                        SetProperty(instance);
                    }
                    else
                    {
                        var instance = Activator.CreateInstance(prop.PropertyType);
                        prop.SetValue(_object, instance, null);
                        SetProperty(instance);
                    }
                }
            }
        }
    }
