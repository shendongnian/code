    private string _username;
    [DataMember(Name="username")]
    public string Username
    {
        get { return _username; }
        set { SetField(ref _username, value); }
    }
    private void SetField<T>(ref T field, T value,
        [CallerMemberName] string memberName = null)
    {
        if(!EqualityComparer<T>.Default.Equals(field,value))
        {
            field = value;
            RaisePropertyChanged(memberName);
        }
    }
