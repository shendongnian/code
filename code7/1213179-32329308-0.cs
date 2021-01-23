                int[] data;
                var obj = topicDetails;// topicDetails= new List<TopicDetails> { };// List of DataContracts{ BaseObjectType = ":EQUIPMENT", TopicID = "42" };
                var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(List<TopicDetails>));
                using (var stream = new System.IO.MemoryStream())
                {
                    serializer.WriteObject(stream, obj);
                    data = new int[stream.Length];
                    stream.Position = 0;
                    for (int i = 0; i < data.Length; i++)
                        data[i] = stream.ReadByte();
                }
