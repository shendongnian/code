    public class YearsCollection : ObservableCollection<Year>
    {
    }
    ...
    YearsCollection _years = new YearsCollection();
    public YearsCollection Years
    {
        get { return _years; }
        set
        {
            //ignore if values are equal
            if (value == _years) return;
            _years = value;
            OnPropertyChanged("Years");
        }
    }
    public IList Children
    {
        get
        {
            return new[]
            {
                this.Years
                ...
            };
        }
    }
