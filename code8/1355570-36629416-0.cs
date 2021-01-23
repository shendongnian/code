            List<int> NumList = new List<int>();
            NumList.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7,
                8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21,
                22, 23, 24, 25, 26, 27, 28, 29, 30 });
            int index = randomInstance.Next(0, NumList.Count - 1);
            int randomNumber = NumList[index];
            NumList.RemoveAt(index);
