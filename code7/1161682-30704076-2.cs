        static void saveFunction(List<int> data, string name)
        {
            using (Stream stream = File.Open(name + ".bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bin = new BinaryFormatter();
                if (stream.Length == 0)
                {
                    var List = new List<List<int>>();
                    List.Add(data);
                    bin.Serialize(stream, List);
                }
                else
                {
                    var List = (List<List<int>>)bin.Deserialize(stream);
                    List.Add(data);
                    stream.SetLength(0); // Clear the old data from the file
                    bin.Serialize(stream, List);
                }
            }
        }
