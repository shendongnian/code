    [Serializable()]
    class NodeTag : ISerializable
        {
            public NodeTag(string Subnet)
            {
             Broadcast_Address = Stuff;
             Network_Name = Stuff;
             CIDR_Value = Stuff;
             }
            public string Network_Name { get; set; }
            public string CIDR_Value { get; set; }
            public string Broadcast_Address { get; set; }
            //Deserializer - loads back from file data
            //This is an overloaded function that defines the data object when it is being reconstituted
            public NodeTag(SerializationInfo info, StreamingContext context)
            {
                Network_Name = (String)info.GetValue("Network_Name", typeof(string));
                CIDR_Value = (String)info.GetValue("CIDR_Value", typeof(string));
                Broadcast_Address = (String)info.GetValue("Broadcast_Address", typeof(string));
            }
            //Serializer - loads into file data
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Network_Name", Network_Name);
                info.AddValue("CIDR_Value", CIDR_Value);
                info.AddValue("Broadcast_Address", Broadcast_Address);
            }
        }
