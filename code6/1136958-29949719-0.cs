    public class Program
    {
        public static string[] tempStringArr = new string[5] { "Hey", "Greetings", "Hello", "Hi", "Example" };
        public static string tempKey = "Hello";
        static void Main(string[] args)
        {
            int testResult = linearSearchTitleTest(tempKey, tempStringArr);
            Debug.WriteLine(Convert.ToString(testResult));
        }
        public static int linearSearchTitleTest(string titleKey, string[] titleArr)
        {
            for (int i = 0; i < titleArr.Length - 1; i++)
            {
                if (titleKey == titleArr[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
