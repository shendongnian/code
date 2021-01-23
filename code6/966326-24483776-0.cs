    public interface ICommand
    {
        void Execute(string vars);
        void Undo();
        string GetName();
    }
