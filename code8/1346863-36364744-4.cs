    using System.Runtime.CompilerServices;
    using System.ComponentModel;
    //  ... snip ...
    public event PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
