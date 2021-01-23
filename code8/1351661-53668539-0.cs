        //.Net source
        internal string Serialize(object obj, SerializationFormat serializationFormat)
        {
            StringBuilder sb = new StringBuilder();
            Serialize(obj, sb, serializationFormat);
            return sb.ToString();
        }
