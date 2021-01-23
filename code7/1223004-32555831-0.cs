    public class MyConsole
    {
        private readonly BlockingCollection<string> m_Lines = new BlockingCollection<string>();
        public string ReadLine()
        {
            return m_Lines.Take();
        }
        private void AddNewLine(string new_line)
        {
            m_Lines.Add(new_line);
        }
        //...
    }
