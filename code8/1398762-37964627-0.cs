    public static class ListUtils
    {
        public static bool ListsHaveCommonality<T1,T2>(
            List<T1> listOne,
            List<T2> listTwo,
            Func<T1, string> selectorOne,
            Func<T2, string> selectorTwo)
        {
            return listOne.Select(selectorOne).Intersect(listTwo.Select(selectorTwo)).Any();
        }
    }
