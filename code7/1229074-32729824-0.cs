    // Put this registration in composite root
    var unityContainer = new UnityContainer();
    unityContainer.RegisterType<IGame, TictacToe>("tictactoe");
    unityContainer.RegisterType<IGame, TrivialPursuit>("triviapursuit");
    unityContainer.RegisterType<IGame, Mario>("mario");
    unityContainer.RegisterType<IGameFactory, GameFactory>(unityContainer);
    unityContainer.RegisterType<IGameService, GameService>();
    unityContainer.RegisterType<ITable, Table>();
    // Game factory implementation
    public class GameFactory : IGameFactory
    {
         private readonly IUnityContainer _unityContainer;
         
         public GameFactory(IUnityContainer unityContainer)
         {
             if( unityContainer == null )
                 throw new NullReferenceException("unityContainer");
                 
             _unityContainer = unityContainer;
         }
         
         // GameType should be equal to the name upon registratoin 
         // Ex. Game registered is tictactoe
         //     GameType should be also tictactoe upon resolving.
         public ITable CreateGame(string gameType)
         {
             var gameSelected = _unityContainer.Resolve<IGame>(gameType)
    
             return _unityContainer.Resolve<ITable>(new ResolverOverride[]
             {
                 new ParameterOverride("IGame", gameSelected)
             });
         }
    }
    
    // Game service implementation
    public class GameService : IGameService
    {
         private readonly IGameFactory _gameFactory;
         
         public GameService(IGameFactory gameFactory)
         {
             if( gameFactory == null )
                 throw new NullReferenceException("gameFactory");
                 
             _gameFactory = gameFactory;
         }
             
         // To avoid exception for unkown gametype enforce with constant 
         // variable or enum depend on your choice
         public void StartGame(string gameType)
         {
             var tableGame = _gameFactory.CreateGame(gameType);
              
             tableGame.Play();
             tableGame.GameStatus();    
         }
    }
