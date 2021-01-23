    using System;
    using System.Collections.Generic;
    
    namespace Dapper
    {
        public class DapperParam
        {
            /// <summary>
            ///     Parameter Type Constructor
            /// </summary>
            /// <param name="paramName"></param>
            /// <param name="paramType"></param>
            /// <param name="paramDirection"></param>
            /// <param name="paramValue"></param>
            public DapperParam(string paramName,
                            Type paramType,
                            string paramDirection,
                            object paramValue)
            {
                ParamName = paramName;
                ParamType = paramType;
                ParamDirection = paramDirection;
                ParamValue = paramValue;
            }
    
            /// <summary>
            ///     Parameter name
            /// </summary>
            public string ParamName { get; set; }
    
            /// <summary>
            ///     Parameter Type
            /// </summary>
            public Type ParamType { get; set; }
    
            /// <summary>
            ///     Parameter Direction
            /// </summary>
            public string ParamDirection { get; set; }
    
            /// <summary>
            ///     Parameter Value
            /// </summary>
            public object ParamValue { get; set; }
           
        }
    
        internal static class DataConversionMap
        {
            /// <summary>
            ///     Type conversion, handles null
            /// </summary>
            /// <param name="obj"></param>
            /// <param name="func"></param>
            /// <returns></returns>
            private static object ConvertDbData(object obj, Func<object> func)
            {
                return (!Convert.IsDBNull(obj)) ? func() : null;
            }
    
            /// <summary>
            ///     Dictionary map to convert to a given DataType. Returns a Func of object,object.
            ///     Internally calls ConvertDbData for Data Type conversion
            /// </summary>
            public static readonly Dictionary<Type, Func<object, object>> Map =
                new Dictionary<Type, Func<object, object>>
                {
                    {
                        typeof(Int16),
                        objectValue => ConvertDbData(objectValue, () => Convert.ToInt16(objectValue))
                    },
    
                    {
                        typeof(Int32),
                        objectValue => ConvertDbData(objectValue, () => Convert.ToInt32(objectValue))
                    },
    
                    {
                        typeof(Int64),
                        objectValue => ConvertDbData(objectValue, () => Convert.ToInt64(objectValue))
                    },
    
                    {
                        typeof(Boolean),
                        objectValue => ConvertDbData(objectValue, () => Convert.ToBoolean(objectValue))
                    },
    
                    {
                        typeof(string),
                        objectValue => ConvertDbData(objectValue, () => Convert.ToString(objectValue))
                    },
    
                    {
                       typeof(DateTime), objectValue =>
                        
                            ConvertDbData(objectValue, () =>
                            {
                                DateTime dateTime = Convert.ToDateTime(objectValue);
    
                                if (dateTime.TimeOfDay.Equals(TimeSpan.Zero))
                                    return dateTime.ToShortDateString();
    
                                return dateTime.ToString("MM/dd/yyyy HH:mm");
                            })
                        
                    },
    
                    {
                        typeof(Byte),
                        objectValue => ConvertDbData(objectValue, () => Convert.ToByte(objectValue))
                    },
    
                    {
                        typeof(Double),
                        objectValue => ConvertDbData(objectValue, () => Convert.ToDouble(objectValue))
                    },
    
                    {
                        typeof(Decimal),
                        objectValue => ConvertDbData(objectValue, () => Convert.ToDecimal(objectValue))
                    },
    
                    {
                        typeof(TimeSpan),
                        objectValue => ConvertDbData(objectValue, () => TimeSpan.Parse(objectValue.ToString()))
                    },
    
                    {
                        typeof(Guid),
                        objectValue => ConvertDbData(objectValue, () => new Guid(objectValue.ToString()))
                    },
    
                    {
                        typeof(Byte[]),
                        objectValue => ConvertDbData(objectValue, () => (Byte[])(objectValue))
                    }
                };
        }
    }
