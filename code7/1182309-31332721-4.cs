    public class ListEditor<T> where T : new()
    {
        private readonly List<T> originalList;
        public ListEditor(List<T> list)
        {
            originalList = list;
        }
        public void AddMember()
        {
            originalList.Add(new T());
        }
    }
    var originalApples = new List<Apple>();
    var newApples = new ListEditor<Apple>(originalApples);
    newApples.AddMember();
