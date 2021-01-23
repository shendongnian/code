    public class EnumData
    {
        public string Enum { get; set; }
        public bool IsChecked { get; set; }
    }
    var enumData = new ObservableCollection<EnumData> (Enum.GetNames(typeof(YourEnum))
        .Select(s => new EnumData { Enum = s, IsChecked = false }));
