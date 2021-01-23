    using System.Windows.Forms;
    namespace Games_Manager
    {
        public class Game
        {
            public string Name;
            public string Path;
            public Game(string name, string path)
            {
                Name = name;
                Path = path;
            }
        }
    
        public partial class MainWin : Form
        {
            List<Game> games;  //here is where the games will be stored
            public MainWin()
            {
                InitializeComponent();
                games = new List<Game>(); //here the list is initialized
            }
    
            public void AddGame(string gameName, string gamePath)
            {
                games.Add(new Game(gameName, gamePath)); //add a game to the list
            }
        }
    }
