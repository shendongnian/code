    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    namespace ModelBinderPoc
    {
    public class MyModelBinder : IModelBinder
    {
        private bool IsPropertyClrObject(PropertyInfo obj)
        {
            var type = obj.PropertyType;
            return (type.Equals(typeof(Boolean)) || type.Equals(typeof(string)) || type.Equals(typeof(Int32)) || type.Equals(typeof(decimal))
                || type.Equals(typeof(DateTime)) || type.Equals(typeof(DateTime?)));
        }
        private void SetClrObjectValue(PropertyInfo pinfo, object model, object pvalue)
        {
            pinfo.SetValue(model, pvalue, null);
        }
        private object CreateCollection(object obj, string propertyPart)
        {
            var propertyLength = propertyPart.IndexOf('[');
            var propertyName = propertyPart.Substring(0, propertyLength);
            var index = propertyPart.Substring(propertyLength + 1, propertyPart.Length - (propertyLength + 2));
            var property = obj.GetType().GetProperty(propertyName);
            var propertyValue = property.GetValue(obj, null);
            if (propertyValue == null)
            {
                var ctype = property.PropertyType.GetGenericTypeDefinition();
                if (ctype.FullName.Contains("System.Collections.Generic.IList"))
                {
                    var gptype = property.PropertyType.GetGenericArguments().First();
                    var listInstance = (IList)typeof(List<>).MakeGenericType(gptype).GetConstructor(Type.EmptyTypes).Invoke(null);
                    property.SetValue(obj, listInstance, null);
                    propertyValue = listInstance;
                }
            }
            int count = (int)propertyValue.GetType().GetProperty("Count").GetValue(propertyValue, null);
            var gtype = propertyValue.GetType().GetGenericArguments().First();
            object listItem = null;
            if (int.Parse(index) + 1 > count)
            {
                ((IList)propertyValue).Add(listItem = gtype.GetConstructor(Type.EmptyTypes).Invoke(null));
            }
            else
            {
                listItem = propertyValue.GetType().GetMethod("get_Item").Invoke(propertyValue, new object[] { int.Parse(index) });
            }
            return listItem;
        }
        private void setPropertyValue(object model, string propertyName, string value)
        {
            var objectValue = model;
            foreach (var propertyPart in propertyName.Split('.'))
            {
                var propertyLength = propertyPart.Length;
                if ((propertyLength = propertyPart.IndexOf('[')) != -1)
                {
                    objectValue = CreateCollection(objectValue, propertyPart);
                    continue;
                }
                var property = GetProperty(objectValue, propertyPart);
                if (property == null)
                    return; // invalid property
                if (IsPropertyClrObject(property))
                {
                    SetValue(objectValue, property, value);
                    return;
                }
                var propertyValue = GetValueOf(objectValue, property);
                if (propertyValue == null)
                {
                    var newObjValue = GetNewValueFor(property);
                    SetObjValue(objectValue, property, newObjValue);
                    propertyValue = newObjValue;
                }
                objectValue = propertyValue;
            }
        }
        private void SetValue(object obj, PropertyInfo pinfo, object value)
        {
            if (pinfo.PropertyType.Equals(typeof(DateTime?)))
            {
                DateTime date = DateTime.Now;
                if (DateTime.TryParse(value as string, out date))
                    pinfo.SetValue(obj, date, null);
                else
                    pinfo.SetValue(obj, null, null);
                return;
            }
            if (value.ToString().Length != 0) 
                pinfo.SetValue(obj, Convert.ChangeType(value, pinfo.PropertyType), null);
        }
        private void SetObjValue(object obj, PropertyInfo pinfo, object value)
        {
            pinfo.SetValue(obj, value, null);
        }
        private object GetValueOf(object obj, PropertyInfo pinfo)
        {
            return pinfo.GetValue(obj, null);
        }
        private object GetNewValueFor(PropertyInfo pinfo)
        {
            return Instantiate(pinfo.PropertyType);
        }
        private object Instantiate(Type type)
        {
            return type.GetConstructor(Type.EmptyTypes).Invoke(null); ;
        }
        private PropertyInfo GetProperty(object obj, string property)
        {
            return obj.GetType().GetProperty(property);
        }
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = Instantiate(bindingContext.ModelType);
            var parameters = controllerContext.HttpContext.Request.Params;
            foreach (var key in parameters.AllKeys)
            {
                var value = parameters.GetValues(key);
                setPropertyValue(model, key, value.First());
            }
            return model;
        }
    }
    }`    
    
