    public class Program
    {
        public delegate void NewLineCallback(string lineContent);
        public static void NewLineReceived(string lineContent)
        {
            if (lineContent != null)
            {
                Console.WriteLine("New line has been read from the file. Number of chars: {0}. Timestamp: {1}", lineContent.Length, DateTime.Now.ToString("yyyyMMdd-HHmmss.fff"));
            }
            else
            {
                Console.WriteLine("All the file content have been read. Timestamp: {0}", DateTime.Now.ToString("yyyyMMdd-HHmmss.fff"));
            }
        }
        public static async void ReadFile(NewLineCallback newLineCallback)
        {
            StreamReader fileInputStreamReader = new StreamReader(File.OpenRead("c:\\temp\\mytemptextfile.txt"));
            
            string newLine;
            
            do
            {
                newLine = await fileInputStreamReader.ReadLineAsync();
                newLineCallback(newLine);
            }
            while (newLine != null);
        }
        public static void Main(string[] args)
        {
            ReadFile(NewLineReceived);
            Console.ReadLine(); // To wait for the IO operation to complete.
        }
    }
