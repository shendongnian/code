    using System;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                char[] ar = { 'a', 'h', 'm', 'a', 'd' };
                char[] ay = { 'a', 'y', 'f', 'm', 'a', 'd' };
                Console.WriteLine(GetDiffOfCharArray(ay, ar, "ay", "ar"));
                ay = new char[] { 'a', 'h', 'm', 'a', 'd' };
                Console.WriteLine(GetDiffOfCharArray(ay, ar, "ay", "ar"));
                Console.ReadLine();
            }
    
            private static string GetDiffOfCharArray(char[] array1Values, char[] array2Values, string array1Name, string array2Name)
            {
                string result = "";
    
                if (array1Values.SequenceEqual(array2Values))
                {
                    result = string.Format("Success, Array '{0}' matches Array '{1}'", array1Name, array2Name);
                }
                else
                {
                    var diff = array1Values.Except(array2Values);
                    result = string.Format("Failure, the different char is '{0}', it is in the array '{1}' but not in the array '{2}'", 
                        string.Join("','", diff), 
                        array1Name, 
                        array1Name);
                }
                return result;
            }
        }
    }
