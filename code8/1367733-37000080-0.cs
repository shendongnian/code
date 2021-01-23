    public class FirstViewModel : INotifyPropertyChanged
    {
        public delegate void PropertyChangedHandler(object obj);
        public static event PropertyChangedHandler MyPropertyChanged = delegate { };
        public FirstViewModel()
        {
            //Example: here I fire the function in the second ViewModel with parameter
            var obj = new { Name = "Jhon" };
            MyPropertyChanged(obj);
        }
    }
