    public class FileStreamer<T>
    {
        static void SoapSave(SortedSet<T> set, Stream stream)
        {
            var formatter = new SoapFormatter();
            formatter.Serialize(stream, set.ToArray());
        }
        public static SortedSet<T> SoapLoad(Stream stream)
        {
            var formatter = new SoapFormatter();
            var array = (T [])formatter.Deserialize(stream);
            return new SortedSet<T>(array);
        }
        public static bool SoapSave(SortedSet<T> set, string filename)
        {
            using (var stream = File.Create(filename))
            {
                SoapSave(set, stream);
            }
            return true;
        }
        public static SortedSet<T> SoapLoad(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                return SoapLoad(stream);
            }
        }
    }
