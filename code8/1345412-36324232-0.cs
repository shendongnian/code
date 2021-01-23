       static void Main()
       {
            string copyOne = "the quick  brown fox jumps over the lazy dog";
            string hairy = "hairy ";
            string copyTwo;
            copyTwo = string.Copy(copyOne);
            copyTwo = copyTwo.Replace("dog", "chicken");
            copyTwo = copyTwo.Insert(10, hairy);
            copyTwo = copyTwo.TrimEnd();
            Console.WriteLine(copyOne);
            Console.WriteLine();
            Console.WriteLine("" + copyTwo + "");
            Console.ReadLine();
            Console.Clear();
            string lower = (copyTwo);
            Console.WriteLine(lower.ToUpper());
            Console.ReadLine();
            Console.Clear();
            string upper = (copyTwo);
            Console.WriteLine(upper.ToLower());
            Console.ReadLine();
            Console.Clear();
            copyTwo = string.Copy(copyTwo);
            copyTwo = copyTwo.Replace("e", "y");
            Console.WriteLine("" + copyTwo + "");
            Console.ReadLine();
            Console.Clear();
            string[] names = { "Krissi", "Dale", "Bo", "Christopher" };
            double[] wealth = { 150000, 1000000, 5.66, 10 };
            Console.Write("names".PadRight(15));
            Console.WriteLine("wealth".PadLeft(8));
            for (int i = 0; i < 4; i++)
            {
                Console.Write(names[i].PadRight(15));
                Console.WriteLine(wealth[i].ToString().PadLeft(8));
            }
            Console.ReadLine();
            Console.Clear();
            string wordThree = "the brown fox jumps over the lazy dog";
            wordThree = wordThree.Replace("dog", "chicken");
            wordThree = wordThree.Insert(10, hairy);
            wordThree = wordThree.TrimEnd();
            string[] split = wordThree.Split(' ');
            Console.WriteLine(wordThree);
            Console.WriteLine();
            Console.WriteLine("" + wordThree + "");
            string FinalWord = "";
            foreach (string item in split)
            {
                FinalWord = FinalWord + item[0].ToString().ToUpper()
                + item.Substring(1) + " ";
            }
            FinalWord = FinalWord.Trim();
            Console.WriteLine(FinalWord + " ");
            Console.ReadLine();
        }
