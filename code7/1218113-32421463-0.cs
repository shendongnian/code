        private void TestArrays()
        {
            int[,] arrayA = new[,] { { 1, 2 }, { 4, 6 }, { 3, 7 } };
            int[,] arrayB = new[,] { { 3, 2 }, { 1, 2 }, { 8, 5 } };
            int parentLengthA = arrayA.GetLength(0);
            int childLengthA = arrayA.GetLength(1);
            int parentLengthB = arrayB.GetLength(0);
            int childLengthB = arrayB.GetLength(1);
            int[] itemsOfA;
            int[] itemsOfB;
            List<int[]> matchedArrays = new List<int[]>();
            for (int i = 0; i < parentLengthA; i++)
            {
                itemsOfA = new int[childLengthA];
                for (int j = 0; j < parentLengthB; j++)
                {
                    itemsOfB = new int[childLengthB];
                    bool isMatched = true;
                    if (itemsOfA.Length != itemsOfB.Length)
                    {
                        isMatched = false;
                        break;
                    }
                    for (int k = 0; k < itemsOfA.Length; k++)
                    {
                        if (arrayA[i, k] != arrayB[j, k])
                        {
                            isMatched = false;
                            break;
                        }
                        else
                        {
                            itemsOfA[k] = arrayA[i, k];
                        }
                    }
                    if (isMatched)
                    {
                        matchedArrays.Add(itemsOfA);
                    }
                }
            }
            //Just to output the matched array(s)
            if (matchedArrays.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (int[] matchedArray in matchedArrays)
                {
                    foreach (int i in matchedArray)
                    {
                        sb.Append(i + ",");
                    }
                    sb.AppendLine();
                }
                MessageBox.Show(sb.ToString());
            }
        }
  
