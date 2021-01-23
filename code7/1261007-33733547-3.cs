        public class ServerNameString2ColorNamePartValuesConverter : IValueConverter
    {
        
 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var name = value.ToString();
            var verbalNameParts = name.Split(BrushMap.Select(item => item.Key).ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var colorKeyNameParts = name.Split(verbalNameParts, StringSplitOptions.RemoveEmptyEntries);
            if (verbalNameParts.Length != colorKeyNameParts.Length) return null;
            var index = 0;
            var nameMappedToColors = new ObservableCollection<ServerNameParts>();
            verbalNameParts.ToList().ForEach(namePart =>
            {
                var brush = BrushMap.FirstOrDefault(item => item.Key == colorKeyNameParts[index]);
                if(brush == null) return;
                nameMappedToColors.Add(new ServerNameParts
               {
                   NamePart = namePart,
                   NamePartBrush = brush.Brush,
               });
                index++;
            });
            
            return new ServerNameObject{ServerNamePartsCollection = nameMappedToColors};
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public ColorAndKey[] BrushMap { get; set; }
    }
    public class ColorAndKey
    {
        public string Key { get; set; }
        public Brush Brush { get; set; }
    }
    public class ServerNameObject : BaseObservableObject
    {
        public ObservableCollection<ServerNameParts> ServerNamePartsCollection { get; set; }
    }
    public class ServerNameParts : BaseObservableObject
    {
        private string _name;
        private Brush _namePartBrush;
        public Brush NamePartBrush
        {
            get { return _namePartBrush; }
            set
            {
                _namePartBrush = value;
                OnPropertyChanged();
            }
        }
        public string NamePart
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }
