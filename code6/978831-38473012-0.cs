    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace WebAPI
    {
        public class ObjectWrapper
        {
            #region Public Properties
            public string RecordJson { get; set; }
            public string TypeFullName { get; set; }
            #endregion
    
            #region Constructors
    
            public ObjectWrapper() : this(null, null)
            {
            }
    
            public ObjectWrapper(object objectForWrapping) : this(objectForWrapping, null)
            {
            }
    
            public ObjectWrapper(object objectForWrapping, string typeFullName)
            {
                if (typeFullName == null && objectForWrapping != null)
                {
                    TypeFullName = objectForWrapping.GetType().FullName;
                }
                else
                {
                    TypeFullName = typeFullName;
                }
    
                RecordJson = JsonConvert.SerializeObject(objectForWrapping);
            }
            #endregion
    
            #region Public Methods
            public object ToObject()
            {
                var type = Type.GetType(TypeFullName);
                return JsonConvert.DeserializeObject(RecordJson, type);
            }
            #endregion
    
            #region Public Static Methods
            public static List<ObjectWrapper> WrapObjects(List<object> records)
            {
                var retVal = new List<ObjectWrapper>();
                records.ForEach
                (item =>
                {
                    retVal.Add
                    (
                        new ObjectWrapper(item)
                    );
                }
                );
    
                return retVal;
            }
    
            public static List<object> UnwrapObjects(IEnumerable<ObjectWrapper> objectWrappers)
            {
                var retVal = new List<object>();
    
                foreach(var item in objectWrappers)
                {
                    retVal.Add
                    (
                        item.ToObject()
                    );
                }
    
                return retVal;
            }
            #endregion
        }
    }
