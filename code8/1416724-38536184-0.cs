    public INotification Notification
    {
        get
        {
            return notification;
        }
        set
        {
            if (value is ItemSelectionNotification)
            {
                notification = value as ItemSelectionNotification;
                OnPropertyChanged(() => Notification);
                //*** Add ListBox clearing code here!!
    			// Maybe a call to a method -> ClearListBoxes();
            }
        }
    }
