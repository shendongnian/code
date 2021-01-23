    //Better made the class a singleton but I've skipped that part to for brifety
    public class Navigation 
    {
        public bool CanGoBack
        {
            get
            {
                var frame = ((Frame)Window.Current.Content);
                return frame.CanGoBack;
            }
        }
        public Type CurrentPageType
        {
            get
            {
                var frame = ((Frame)Window.Current.Content);
                return frame.CurrentSourcePageType;
            }
        }
        public virtual void GoBack()
        {
            var frame = ((Frame)Window.Current.Content);
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }
        public virtual void NavigateTo(Type sourcePageType)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType);
        }
        public virtual void NavigateTo(Type sourcePageType, object parameter)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType, parameter);
        }
        public virtual void GoForward()
        {
            var frame = ((Frame)Window.Current.Content);
            if (frame.CanGoForward)
            {
                frame.GoForward();
            }
        }
    }
