    public partial class Form1 : Form
    {
        private class ListBoxItem<T> : IComparable<ListBoxItem<T>>
            where T : IComparable<T>
        {
            private T item;
            internal ListBoxItem(T item)
            {
                this.item = item;
            }
            // this makes possible to cast a string to a ListBoxItem<string>, for example
            public static implicit operator ListBoxItem<T>(T item)
            {
                return new ListBoxItem<T>(item);
            }
            public override string ToString()
            {
                return item.ToString();
            }
            public int CompareTo(ListBoxItem<T> other)
            {                
                return item.CompareTo(other.item); // here you can catch the comparison
            }
        }
        public Form1()
        {
            InitializeComponent();
            var items = new List<ListBoxItem<string>> { "Banana", "Apple"};
            items.Sort();
            listBox1.DataSource = items;
        }
