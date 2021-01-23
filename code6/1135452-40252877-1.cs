       public static byte[] GetFile(string name)
        {
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            string filenanme = path + "/" + name;
            byte[] bytes = File.ReadAllBytes(filenanme);
            return bytes;
        }
