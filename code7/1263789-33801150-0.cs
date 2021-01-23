    public class ListBoxViewItem<T>
    {
        public string Name { get; set; }
        
        public ListBoxViewItem(T tInstance)
        {
            .... // current implementation
            Name = <set the name using tInstance>;
        }
    }
