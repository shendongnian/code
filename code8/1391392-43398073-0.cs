        public class IBatchCollectionXmlSerializer : XmlSerializerInputFormatter
        {
            protected override XmlSerializer CreateSerializer(Type type)
            {
                //init expected type
                Type expectedType = typeof(IBatchContent);
                //init xml serializer
                XmlSerializer serializer = null;
                //if not expected type
                if (expectedType != type)
                {
                    //return default serializer
                    serializer = base.CreateSerializer(type);
                }
                //if expected type
                else
                {
                    //add concrete type to deserialize to
                    Type[] extraTypes = new Type[] { typeof (BatchContentConcrete) };
                    //create custom xml serializer here
                    serializer = new XmlSerializer(typeof(IBatchContent), extraTypes);
                }
                //return serializer
                return serializer;
            }
        }
