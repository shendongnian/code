    public class Class1
    {
        private StringBuilder sb = new StringBuilder();
        public void loadFile()
        {
            using(StreamReader sr = new StreamReader("C:\\test.txt"))
            {
                sb.Append(sr.ReadToEnd());
            }
        }
    }
    static void Main()
    {
        fileloader.Class1 inst = new fileloader.Class1();
        do
        {
            if(inst == null)
            {
                inst = new fileloader.Class1();
            }
            for (int i = 0; i < 100; i++)
            {
                inst.loadFile();
            }
            inst = null;  // alows the object to be GC'ed. Without this i get the OutOfMemoryException
            Thread.Sleep(1000);
        } while (true);
    }
