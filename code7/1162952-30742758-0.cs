    [Serializable]
    public MySerializableClass : MyUnforgivingBaseClass
    {
        [OnSerializing]
        public void OnSerializing(StreamingContext context)
        {
             //You can modify the object before serialization here
        }
    
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            //You can modify the object during deserialization here
        }
    }
