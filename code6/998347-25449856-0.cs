    public class CompareSchedules : IEqualityComparer<ScheduleDetail>
    {
        public bool Equals(ScheduleDetail x, ScheduleDetail y)
        {
            return x.HomeHelpID == y.HomeHelpID;
        }
        public int GetHashCode(ScheduleDetail obj)
        {
            return obj.HomeHelpID;
        }
    }
    public static class SuperDuperListComparer
    {
        public class ListCompareResults<T>
        {
            public List<T> RemovedItems { get; set; }
            public List<T> AddedItems { get; set; }
        }
        public static ListCompareResults<T> CompareLists<T>(IList<T> list1, IList<T> list2, IEqualityComparer<T> comparer)
        {
            var addedItems = list2.Except(list1, comparer).ToList();
            var removedItems = list1.Except(list2, comparer).ToList();
            return new ListCompareResults<T>
            {
                AddedItems = addedItems,
                RemovedItems = removedItems
            };
        }
        public static ListCompareResults<T> CompareLists<T>(IList<T> list1, IList<T> list2)
        {
            return CompareLists<T>(list1, list2, EqualityComparer<T>.Default);
        }
    }
