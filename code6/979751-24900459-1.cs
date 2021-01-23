    public class InterfaceImpl : IInterface
    {
        string GetString(string start)
        {
            return start + " okay.";
        }
        void DoSomething()
        {
            Console.WriteLine(GetString("Go"));
        }
    }
