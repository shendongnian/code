    class Program
        {
            static void Main(string[] args)
            {
                char testChar = '&';
                string test1 = "&";
                string test2 = "&&&&&&&&&&";
                string test3 = "&&&&&&&u&&&&&&&";
    
                Console.WriteLine(checkIfOnly(testChar, test1)); // true
                Console.WriteLine(checkIfOnly(testChar, test2)); // true
                Console.WriteLine(checkIfOnly(testChar, test3)); // false
                Console.WriteLine(checkIfOnly('u', test3));      // false
                Console.WriteLine(checkIfOnly('u', "u"));      // true
                Console.WriteLine(checkIfOnly('u', "uuuu"));      // true
    
    
            }
    
            static bool checkIfOnly(char testChar, string s)
            {
                foreach (char c in s)
                {
                    if (c != testChar) return false;
                }
                return true;
            }
    
        }
