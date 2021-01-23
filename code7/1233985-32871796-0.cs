    public class ViewModelBase : BindableBase
    {
        protected bool SetProperty(
            Func<bool> isValueNew,
            Action setValue,
            [CallerMemberName] string propertyName = null)
        {
            if (isValueNew())
            {
                return false;
            }
            setValue();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
