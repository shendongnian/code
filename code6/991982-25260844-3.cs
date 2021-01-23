        public class ViewModel
    {
        public ViewModel()
        {
            Choices = new ObservableCollection<string> { "All", "Left", "Right", "None" };
            Equips = new ObservableCollection<Equip>() { new Equip(), new Equip() };
        }
        public ObservableCollection<Equip> Equips { get; set; }
        public ObservableCollection<string> Choices { get; set; }
    }
