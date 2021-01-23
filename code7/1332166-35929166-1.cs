       public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new Team
                {
                    Players = new List<Player>()
                    { 
                        new Player{ ID=1, FirstName="Mohammed", LastName="Ali" },
                        new Player{ ID=2, FirstName="Paul", LastName="Oshain" },
                    }
                };
            }
        }
