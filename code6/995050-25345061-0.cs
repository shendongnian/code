    using System.Collections.ObjectModel;
    using System.ComponentModel;
    namespace WpfApplication1.ViewModels
    {
        public class SquadViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            private ObservableCollection<Soldier> _squadMembers;
            public ObservableCollection<Soldier> SquadMembers { get { return _squadMembers; } set { _squadMembers = value; OnPropertyChanged("SquadMembers"); } }
            private Soldier _selectedSoldier;
            public Soldier SelectedSoldier { get { return _selectedSoldier; } set { _selectedSoldier = value; OnPropertyChanged("SelectedSoldier"); } }
            public SquadViewModel()
            {
                SquadMembers = new ObservableCollection<Soldier>()
                {
                    new Soldier() { SoldierClass = "Assult Soldier", Equipment = new ObservableCollection<Weapon>() { new Weapon("M4 Rifle", "Compact 45 Pistol") } },
                    new Soldier() { SoldierClass = "SMG Soldier", Equipment = new ObservableCollection<Weapon>() { new Weapon("RPK Machine Gun", "HK Shotgun"), new Weapon("SAW Machine Gun", "Compact 45 Pistol") } },
                    new Soldier() { SoldierClass = "Juggernaut", Equipment = new ObservableCollection<Weapon>() { new Weapon("MP5", "Bowie Knife") } }
                };
            }
        }
        public class Soldier : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            private string _soldierClass;
            public string SoldierClass { get { return _soldierClass; } set { _soldierClass = value; OnPropertyChanged("SoldierClass"); } }
            private ObservableCollection<Weapon> _equipment;
            public ObservableCollection<Weapon> Equipment { get { return _equipment; } set { _equipment = value; OnPropertyChanged("Equipment"); } }
        }
        public class Weapon : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            private string _primary;
            string Primary { get { return _primary; } set { _primary = value; OnPropertyChanged("Primary"); } }
            private string _secondary;
            string Secondary { get { return _secondary; } set { _secondary = value; OnPropertyChanged("Secondary"); } }
            public Weapon(string primary, string secondary)
            {
                this.Primary = primary;
                this.Secondary = secondary;
            }
        }
    }
