            string name = "elements";
            var myList = new List<char>();
            var duplicates = new List<char>();
            foreach (char res in name)
            {
                if (!myList.Contains(res))
                {
                    myList.Add(res);
                }
                else if (!duplicates.Contains(res))
                {
                    duplicates.Add(res);
                }
            }
            foreach (char result in duplicates)
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();
