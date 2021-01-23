    public static void Serialize(List<FileSerilizeObject> List)
        {
            using (Stream stream = File.Open(@"C:\Users\ttest\Desktop\folder1\data.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, List);
                stream.Close();
            }
        }
        public static List<FileSerilizeObject> Deserialised(string OpenPath)
        {
            List<FileSerilizeObject> defo;
            using (Stream stream = File.Open(OpenPath, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                defo = (List<FileSerilizeObject>)bin.Deserialize(stream);
            }
            return defo;
        }
