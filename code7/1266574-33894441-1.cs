    class Program {
        static void Main(string[] args) {
            AppDomain.CreateDomain("Example");
            foreach (var domain in CLRUtil.EnumAppDomains()) {
                Console.WriteLine("Found appdomain {0}", domain.FriendlyName);
            }
            Console.ReadLine();
        }
    }
