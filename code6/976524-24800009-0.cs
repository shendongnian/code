            List<int> listInts = new List<int>();
            listInts.AddRange(new int[] { 1, 3, 5, 7, 9, 13 });
            int index = listInts.IndexOf(3); //The index here would be "1"
            index++; //Check first if the index is in the length
            int element = listInts[index]; //element = 5
