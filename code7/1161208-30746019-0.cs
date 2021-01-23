    /// <summary>
    /// Invoke sender's PropertyChanged event via Reflection???
    /// </summary>
    /// <param name="sender">sender of the event</param>
    /// <param name="prop">The Property name that has changed</param>
    public static void NotifyPropertyChanged(this INotifyPropertyChanged sender, PropertyChangedEventHandler handler, [CallerMemberName] string prop = null)
    {
        handler(sender, new PropertyChangedEventArgs(prop));
    }
