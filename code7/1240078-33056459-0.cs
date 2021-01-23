    class Program
    {
        const string filename = "some file";
        static void Main(string[] args)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(filename);
            string[] find = new string[] { "me", "you" };
            int offsetAfterFind = 32;
            int pos = 0;
            while (pos < bytes.Length)
            {
                bool isFound = false;
                int index = 0;
                while (!isFound && index < find.Length)
                {
                    bool isMatch = true;
                    for (int n = 0; n < find[index].Length; n++)
                    {
                        if (pos + n >= bytes.Length)
                        {
                            isMatch = false;
                        }
                        else
                        {
                            if (bytes[pos + n] != find[index][n]) isMatch = false;
                        }
                    }
                    if (isMatch)
                    {
                        isFound = true;
                        break;
                    }
                    index++;
                }
                if (isFound)
                {
                    Console.WriteLine(String.Format("Found {0} at {1}", find[index], pos));
                    pos += find[index].Length + offsetAfterFind;
                }
                else
                {
                    pos++;
                }
            }
        }
    }
