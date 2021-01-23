    public interface IGame
    {
        GameType Type { get; }
        ReadOnlyCollection<IPlayer> Players { get; }
    }
    public class GameSingle : IGame
    {
        public GameSingle(List<IPlayer> players)
        {
            Players = players.AsReadOnly();
        }
        public GameType Type => GameType.Single;
        public ReadOnlyCollection<IPlayer> Players { get; }
    }
    public class GameOnline : IGame
    {
        public GameOnline(List<IPlayer> players)
        {
            Players = players.AsReadOnly();
        }
        public GameType Type => GameType.Online;
        public ReadOnlyCollection<IPlayer> Players { get; }
    }
    public class GamePlayAndPass : IGame
    {
        public GamePlayAndPass(List<IPlayer> players)
        {
            Players = players.AsReadOnly();
        }
        public GameType Type => GameType.PassAndPlay;
        public ReadOnlyCollection<IPlayer> Players { get; }
    }
