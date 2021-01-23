            ...
            var numberList = new List<int>();
            numberList.AddRange(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var totalNumber = 0;
            foreach (var item in YieldingNotFive(numberList))
            {
                totalNumber += item;
            }
            ...
        private IEnumerable<int> YieldingNotFive(List<int> numberList)
        {
            foreach (int item in numberList)
            {
                if (item != 5)
                {
                    yield return item;
                }
            }
            yield break;
        }
