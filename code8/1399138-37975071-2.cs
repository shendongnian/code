    public class ListEx<T> : List<T>
    {
        public event EventHandler OnItemChange;
    
        public new void Add(T item)
        {
            base.Add(item);
            OnItemChange(this, EventArgs.Empty);
        }
    }
