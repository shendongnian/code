    class Solution {
    public static Dictionary<String, string> phoneBook = new Dictionary<string, string>();
    static void Main(String[] args) {
    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            //string searchText = "sam";
            Int32 N = Convert.ToInt32(Console.ReadLine());
            string readData = "";
            for (Int32 i = 0; i < N; i ++)
            {
                readData = Console.ReadLine();
                if (readData.Trim().Contains(" "))
                    if (!phoneBook.ContainsKey(readData.Trim().Split(' ')[0]))
                        phoneBook.Add(readData.Trim().Split(' ')[0], readData.Trim().Split(' ')[1]);
            }
            
            while ((readData = Console.ReadLine()) != null)
                SearchPhoneNumbers(readData.Trim());
                
        }
        public static void SearchPhoneNumbers(string searchQuery)
        {
            if (phoneBook.ContainsKey(searchQuery))
                Console.WriteLine("{0}={1}", searchQuery, phoneBook[searchQuery]);
            else
                Console.WriteLine("Not found");
        }
    }
