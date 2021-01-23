    public class MyInitAndModify : IInitAndModify<string>
    {
        public string CreateNew()
        {
            return "";
        }
        public void Modify(string item)
        {
            Console.WriteLine("item: \"{0}\".", item);
        }
    }
