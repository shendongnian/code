            var recordList = MyData.Create("1707 ABCD", "1707 XXXX", "1725 DEFG", "1725 HIJK", "1725 LMNOP");
            for (int i = 0; i < recordList.Count; i++)
            {
                var index = recordList.BinarySearch(recordList[i], new RecComparer());
                Debug.Assert(index == i);
            }
