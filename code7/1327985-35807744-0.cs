    using System;
    using System.Windows.Forms;
    namespace ConsoleApplication7
    {
        public class Program
        {
            private static readonly string aString = Strings.String1;
            public static void Main(string[] arccgs)
            {
                MessageBox.Show(string.Format(aString, "AAA", "BBB"));
                Console.ReadLine();
            }
        }
    }
