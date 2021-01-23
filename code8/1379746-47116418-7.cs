    public abstract class EntityString
    {
        [NotMapped]
        Dictionary<string, ListObservableCollection<string>> loc = new Dictionary<string, ListObservableCollection<string>>();
        protected ListObservableCollection<string> Getter(ref string backingFeild, [CallerMemberName] string propertyName = null)
        {
            var file = backingFeild;
            if ((!loc.ContainsKey(propertyName)) && (!string.IsNullOrEmpty(file)))
            {
                loc[propertyName] = GetValue(file);
                loc[propertyName].CollectionChanged += (a, e) => SetValue(file, loc[propertyName]);
            }
            return loc[propertyName];
        }
        protected void Setter(ref string backingFeild, ref ListObservableCollection<string> value, [CallerMemberName] string propertyName = null)
        {
            var file = backingFeild;
            loc[propertyName] = value;
            SetValue(file, value);
            loc[propertyName].CollectionChanged += (a, e) => SetValue(file, loc[propertyName]);
        }
        private List<string> GetValue(string data)
        {
            if (string.IsNullOrEmpty(data)) return new List<string>();
            return data.Split(';').ToList();
        }
        private string SetValue(string backingStore, ICollection<string> value)
        {
            return string.Join(";", value);
        }
    }
