    public class YourViewModelBase : ViewModelBase
    {
        [NotifyPropertyChangedInvocator] // alt + enter = convert auto property to prop  
                                         // with backing field and change notification :)
        override protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
        }
        // .. :)
    }
