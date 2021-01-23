    public interface ITelephone { ... }
    internal class MyTelephone : ITelephone { ... }
    public interface IMusicPlayer { ... }
    internal class MyPlayer : IMusicPlayer { ... }
    public interface IServiceProvider
    {
      T QueryService<T>() where T : class;
    }
    internal class MyDevice : 
    {
      MyTelephone phone = new MyTelephone();
      MyPlayer player = new MyPlayer();
      public T QueryService<T>() where T : class
      {
          if (typeof(T) == typeof(ITelephone)) return (T)(object)phone;
          if (typeof(T) == typeof(IPlayer)) return (T)(object)player;
          return null;
      }
    }
