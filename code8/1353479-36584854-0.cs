    public class TextFileStreamReader
    {
        /// <summary>
        /// Creates an instance of the StreamReaer class for a given file path.
        /// </summary>
        /// <param name="path">The complete file path to be read.</param>
        /// <returns>A new instance of the StreamReader class if the file was successfully read, otherwise null.</returns>
        public static StreamReader CreateStream(string path)
        {
            try
            {
                var reader = new StreamReader(path);
                Console.WriteLine(
                    "File {0} successfully opened.",
                    path);
                return reader;
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine(
                    "Can not find file {0}.",
                    path);
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine(
                    "Invalid directory in the file path.");
            }
            catch (IOException)
            {
                Console.Error.WriteLine(
                    "Can not open the file {0}",
                    path);
            }
            return null;
        }
    }
