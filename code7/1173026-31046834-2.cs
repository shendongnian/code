    public class ConvertBase64ToFile
    {
        public static void ConvertToFile(string location, string file)
        {
            byte[] bytes = Convert.FromBase64String(file);
            File.WriteAllBytes(location, bytes);
        }
    }
