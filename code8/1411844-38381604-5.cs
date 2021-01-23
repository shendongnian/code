            private static void Serialize(Type serializableType, Object objectToSerialize, FileStream fs)
            {
                 MemoryStream stream1 = new MemoryStream();
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(serializableType));
