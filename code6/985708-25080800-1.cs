     public class MainViewModel
    {
        public ObservableCollection<ButtonDescription> ButtonDescriptions { get; private set; }
        public MainViewModel()
        {
            ButtonDescriptions = new ObservableCollection<ButtonDescription>();
            for (int i = 0; i < 10; i++)
            {
                var bd = new ButtonDescription() { Name = "Button " + i };
                ButtonDescriptions.Add(bd);
            }
        }
    }
