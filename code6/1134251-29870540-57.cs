    /// <summary>
    /// Represents terminal presenter that UI can operate upon.
    /// </summary>
    public interface IGlobalTerminalPresenter
    {
        void UpdateUI();
        void Do1();
        void Do2();
        Int32 SelectedIndex
        {
            get;
            set;
        }
        void Reset();
    }
