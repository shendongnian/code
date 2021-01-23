    namespace ComboBoxTest
    {
        public class ComboBoxItem
        {
            public string ComboBoxOption { get; set; }
            public string ComboBoxHumanReadableOption { get; set; }
        }
    
        public sealed partial class MainPage : Page, INotifyPropertyChanged
        {
            ...
        }
    }
