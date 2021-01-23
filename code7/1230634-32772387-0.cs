    public interface IHost
    {
        /// <summary>
        ///     Destroys the current view and creates a new from name
        /// </summary>
        /// <param name="name">The name of the view you wish to start</param>
        void SwitchView(string name);
        View CurrentView { get; }
    }
