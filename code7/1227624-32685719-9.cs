    List<object[]> newList = new List<object[]>();
    for(int i = 0; i < myList[0].Count; i++)
    {
        for(int i2 = 0; i2 < myList[1].Count; i2++)
        {
            for(int i3 = 0; i3 < myList[2].Count; i3++)
            {
                for(int i4 = 0; i4 < myList[3].Count; i4++)
                {
                    object[] temp = new object[]{myList[0][i], myList[1][i2], myList[2][i3], myList[3][i4]};
                    newList.Add(temp);
                }
            }
        }
    }
