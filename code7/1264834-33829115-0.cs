    public interface IMyInterface
    {
        // This event is raised whenever the value of Text is modified:
        event Action<IMyInterface, string> TextChanged;
        string Text { get; set; }
    }
