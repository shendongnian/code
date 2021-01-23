        public void Serialize(object obj, StringBuilder output)
        {
            Serialize(obj, output, SerializationFormat.JSON);
        }
        
        //usage afterwards
        sb.ToString(0, 100000);
