    class Program
    {
        static void Main(string[] args)
        {
            Random newObject = new Random();
            newObject.Name = "Johnny";
            var result = newObject.IsRunning();
        }
    }
