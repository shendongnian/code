    public static object ReadObjectFromPEMFile(string fileName)
            {
                PemReader reader = new PemReader(new StreamReader(File.Open(fileName, FileMode.Open)));
                object r = reader.ReadObject();
                reader.Reader.Close();
                return r;
            }
