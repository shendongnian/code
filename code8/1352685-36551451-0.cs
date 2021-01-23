        int[] source = {0, 1, 0, 1, 1};
        List<int> tempList = new List<int>(source);
        int totalChanges = 20;
        Random random = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < totalChanges; i++)
        {
            int index = tempList.Count == 0 ? 0 : random.Next(0, tempList.Count); //return either 0 if empty  or a random position
            tempList.Insert(index, random.Next(0,1));
        }
        int[] result = tempList.ToArray();
