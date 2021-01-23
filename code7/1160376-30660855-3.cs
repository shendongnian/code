    class SimpleOverloadTest
    {
        private static T GetCookie<T>(string key, T value)
        {
            return value;
        }
        private static int GetCookie(string key, int value)
        {
            return -1;
        }
        static void Main()
        {
            Console.WriteLine(GetCookie("foo", default(int)));
            Console.WriteLine(GetCookie("foo", default(float)));
            Console.ReadLine();
        }
    }
