        /// <summary>
        /// Convert object to JSon string (supported from .Net 4)
        /// </summary>
        public static string ObjectToJson<T>(T obj)
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer js = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, obj);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            return sr.ReadToEnd();
        }
        /// <summary>
        /// Reverse JSon string back to object (supported from .Net 4)
        /// </summary>
        public static T JsonToObject<T>(string strJson)
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer js = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(strJson));
            T obj = (T)js.ReadObject(ms);
            return obj;
        }
