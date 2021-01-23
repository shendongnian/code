           static public List<int> AddToList(int index,int value,  List<int> input)
            {
                if (index >= input.Count)
                {
                    int[] temparray = new int[index - input.Count + 1];
                    input.AddRange(temparray);
                }
                return (input[index] = value);
            }
