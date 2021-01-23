     static List<string[]> SortedList(string[] input)
        {
            var sort = new string[6] { "Serial", "Width", "Height", "Active1", "Active2", "Time" };
            List<string[]> output = new List<string[]>();
            for (int i = 0; i < sort.Length; i++)
            {
                var findIndex = input.ToList().IndexOf(sort[i]);
                if (findIndex != -1)
                    output.Add(new string[3]
                        {
                            input[findIndex],
                            input[findIndex + 1],
                            input[findIndex + 2]
                        });
                else
                    output.Add(new string[3]
                    {
                        sort[i],
                        null,
                        null
                    });
            }
            return output;
        }
