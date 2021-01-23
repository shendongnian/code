    class MainViewModel : ViewModelBase
        {
            /// <summary>
            /// Référence de la fenêtre principale
            /// </summary>
            private MainWindow mainWindow;
    
            /// <summary>
            /// Liste des personels
            /// </summary>
            private ObservableCollection<Personel> personels = new ObservableCollection<Personel>();
    
    
            public ObservableCollection<Personel> Personels
            {
                get 
                {
                    return personels;
                }
            }
    
            /// <summary>
            /// Constructeur de la classe
            /// </summary>
            /// <param name="mainWindow">Référence de la fenêtre principale</param>
            public MainViewModel(MainWindow mainWindow)
            {
                this.mainWindow = mainWindow;
    
                AddPersonel("Toto");
    
                AddPersonel("Jack");
    
                AddPersonel("Momo");
    
                AddPersonel("Momo");
    
                AddPersonel("Momo");
    
                AddPersonel("Momo");
            }
    
            private void AddPersonel(string namePersonel)
            {
                personels.Add(new Personel() { Name = namePersonel });
                OnPropertyChanged("Personels");
            }
        }
    
        class Personel
        {
            private string name = "NoName";
    
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }
