     public void sift (int i)
        {
            while (i != 0)
            {
                if (compare(heapData[i], parentValue(i)))
                {
                    switchValuesAtIndexes(parentIndex(i), i);
                    i = parentIndex(i);
                }
                else
                    break;
            }
        }
