    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    
    namespace YourNamespace.Extensions
    {
        public enum PropertyFormat
        {
            AsIs,
            PascalCase,
            CamelCase
        }
    
        public static class DataShapingExtensions
        {
            public static object ToDataShape<ObjectIn>(this ObjectIn objectToShape, string fields, PropertyFormat propertyFormat = PropertyFormat.AsIs) where ObjectIn : class
            {
                var listOfFields = new List<string>();
    
                if (!string.IsNullOrWhiteSpace(fields))
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }
    
                if (listOfFields.Any())
                {
                    var objectToReturn = new JObject();
    
                    //====
                    var enumerable = objectToShape as IEnumerable;
    
                    if (enumerable != null)
                    {
                        var listOfObjects = new List<JObject>();
    
                        foreach (var item in enumerable)
                        {
                            var objectToReturn2 = new JObject();
    
                            listOfFields.ForEach(field =>
                            {
                                try
                                {
                                    var prop = item.GetType()
                                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    
                                    var fieldName = prop.Name;
                                    var fieldValue = prop.GetValue(item, null);
    
                                    fieldName = GetName(fieldName, propertyFormat);
                                    objectToReturn2.Add(new JProperty(fieldName, fieldValue));
                                }
                                catch (Exception ex) { }
                            });
    
                            listOfObjects.Add(objectToReturn2);
                        }
    
                        return listOfObjects.ConvertAll(o => o);
                    }
                    //====
    
                    listOfFields.ForEach(field =>
                    {
                        try
                        {
                            var prop = objectToShape.GetType()
                                .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    
                            var fieldName = prop.Name;
                            var fieldValue = prop.GetValue(objectToShape, null);
    
                            fieldName = GetName(fieldName, propertyFormat);
                            objectToReturn.Add(new JProperty(fieldName, fieldValue));
                        }
                        catch (Exception ex) { }
                    });
    
                    return objectToReturn;
                }
    
                return objectToShape;
            }
    
            private static string GetName(string field, PropertyFormat propertyFormat)
            {
                switch (propertyFormat)
                {
                    case PropertyFormat.AsIs: return field;
                    case PropertyFormat.PascalCase: return field.ToPascalCase();
                    case PropertyFormat.CamelCase: return field.ToCamelCase();
                    default: return field;
                }
            }
        }
    }
