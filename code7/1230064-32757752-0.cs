    /// <summary>
    /// Class containing a load and store method to store a datafile as XML format.
    /// </summary>
    /// <typeparam name="T">The root object containing the data</typeparam>
    public class DataFile<T> where T : new()
    {
        /// <summary>
        /// Load the XML from Path
        /// </summary>
        /// <param name="path">Path to a XML file containing the data for object of type T</param>
        /// <returns>An object of type T as represented by the XML. Will return default(T) when the </returns>
        public static T Load(string path)
        {
            if (!File.Exists(path)) return default(T);
            var ser = new XmlSerializer(typeof(T));
            using (var stream = File.OpenRead(path))
            {
                var reader = new XmlTextReader(stream);
                if (!ser.CanDeserialize(reader))
                    return default(T); // return null indicating the file can not be loaded
                return (T) ser.Deserialize(reader);
            }
        }
        /// <summary>
        /// Stores an object of type T as XML into a file
        /// </summary>
        /// <param name="path">A path to a file which should be written.</param>
        /// <param name="data">The object to be written to the given file</param>
        public static void Store(string path, T data)
        {
            var ser = new XmlSerializer(typeof(T));
            using (var stream = File.OpenWrite(path))
            {
                // Clear the file and write new contents.
                stream.SetLength(0);
                ser.Serialize(stream, data);
            }
        }
    }
