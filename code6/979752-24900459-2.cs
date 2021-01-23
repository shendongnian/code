    public class InterfaceImpl : IInterface
    {
        public string GetString(string start)
        {
            return start + " okay.";
        }
        public void DoSomething()
        {
            Console.WriteLine(GetString("Go"));
        }
    }
