    [JsonIgnore]
        public double IsUnreadOpacity
        {
            get { return (IsUnread) ? 1 : 0; }
        }
    public bool IsUnread
        {
            get { return _isUnread; }
            set
            {
                if (value == _isUnread)
                    return;
                Set(ref _isUnread, value);
                RaisePropertyChanged(nameof(IsUnreadOpacity));
            }
        }
 
