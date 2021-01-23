    /// <summary>
    /// Represents internal terminal presenter that is used inside IGlobalTerminalPresenter.
    /// </summary>
    public interface ITerminalPresenter
    {
        void UpdateUI();
        ITerminalPresenter this[Int32 index]
        {
            get;
        }
        ITerminalPresenter Do1();
        ITerminalPresenter Do2();
        ITerminalPresenter Parent
        {
            get;
            set;
        }
        void Reset();
    }
