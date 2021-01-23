        static void Main(string[] args)
        {
            const string text = "Is it allowed to enter this room without asking?";
            string newText = null;
            int count = 0;
            foreach (char c in text)
            {
                string temp = c.ToString();
                if (c == ' ')
                {
                    count ++;
                    bool placeNewLine = false;
                    Random random = new Random();
                    if (random.Next(0, 2) == 1) placeNewLine = true;
                    if (count == 4 || (placeNewLine && count ==3))
                    {
                        temp = Environment.NewLine;
                        count = 0;
                    }
                }
                newText += temp;
            }
            Console.WriteLine(newText);
            Console.ReadLine();
        }
