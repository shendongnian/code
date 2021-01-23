      List<List<int>> GetTree(string data)
        {
            List<List<int>> CompleteTree = new List<List<int>>();
            List<int> ValuesInLine = new List<int>();
            int partsinrow = 1;
            int counter = 0;
            foreach (string part in data.Split('#'))
            {
                int value = int.Parse(part);
                ValuesInLine.Add(value);
                if (++counter == partsinrow)
                {
                    CompleteTree.Add(ValuesInLine);
                    ValuesInLine = new List<int>();
                    counter = 0;
                    partsinrow++;
                }
            }
            return CompleteTree;
        }
