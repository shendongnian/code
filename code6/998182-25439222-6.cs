    int[] arrOfHighest = new int[arr.Length];
            int[] arrOfLowest = new int[arr.Length];
            int minCounter = 0;
            int maxCounter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Lowest == arr[i])
                {
                    arrOfLowest[minCounter] = arr[i];
                    minCounter++;
                }
                if (Highest == arr[i])
                {
                    arrOfHighest[maxCounter] = arr[i];
                    maxCounter++;
                }
            }
            int sumLoewst = 0;
            for (int i = 0; i < arrOfLowest.Length; i++)
            {
                sumLoewst += arrOfLowest[i];
            }
            int sumHighest = 0;
            for (int i = 0; i < arrOfHighest.Length; i++)
            {
                sumHighest += arrOfHighest[i];
            }
            sum -= (sumLoewst + sumHighest);
