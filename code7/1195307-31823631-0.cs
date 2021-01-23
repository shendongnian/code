        using System.Web.Script.Serialization;
        public static TB CastToBase<T, TB>(this T derivedTypeInstance) 
            {
                var serializer = new JavaScriptSerializer();
                var baseTypeInstance = serializer.Deserialize<TB>(serializer.Serialize(derivedTypeInstance));
                return baseTypeInstance;
            } 
