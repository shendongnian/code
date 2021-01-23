        //Create an interface to abstract away the implementation of the static GlobalCommands class
    public interface IGlobalCommands
    {
        CompositeCommand SaveAllCommand { get; }
    }
    public static class GlobalCommands
    {
        public static CompositeCommand SaveAllCommand = new CompositeCommand();
    }
    //Create a facade around the static GlobalCommands class
    public class GloablCommandsFacade : IGlobalCommands
    {
        public CompositeCommand SaveAllCommand
        {
            get { return GlobalCommands.SaveAllCommand; }
        }
    }
