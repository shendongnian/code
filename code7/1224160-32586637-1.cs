    public class BaseData {}
    public class BaseGroup<T> where T : BaseData
    {
        public List<T> DataList;
    }
    public class ChildData : BaseData {}
    public class ChildGroup : BaseGroup<ChildData>
    {
        // No need for a separate list here
    }
