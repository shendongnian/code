    public class ListEditor<T> : List<T> where T : new()
    {
        private readonly List<T> originalList;
        public ListEditor(List<T> list)
        {
            originalList = list;
            AddRange(list);
        }
        public void AddMember()
        {
            var t = new T();
            originalList.Add(t);
            Add(t);
        }
    }
