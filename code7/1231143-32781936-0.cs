    public interface IComboBoxItem
    {
        public int Key { get; }
    }
    public class ComboBoxItem<T> : IComboBoxItem
    {
        public T Value { get; set; }
        public int Key { get; set; }
    }
