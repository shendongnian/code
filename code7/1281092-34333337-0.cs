    public class ParentModelJSONConverter : JavaScriptConverter
        {
    
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                throw new ApplicationException("Serializable only");
            }
    
            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                ParentModel myobj = obj as ParentModel;
                if (myobj != null)
                {
                    // Add your conditions
                    result.Add("MyKeyName", myobj.myModel);
                }
                return result;
            }
    
            public override IEnumerable<Type> SupportedTypes
            {
                get { return new Type[] { typeof(ParentModel) }; }
            }
        }
