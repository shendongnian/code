    public class ListEditor<T> : List<T> where T : new()
    {
        public void AddMember()
        {
            Add(new T());
        }
    }
