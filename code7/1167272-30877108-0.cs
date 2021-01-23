    public interface IConnected {
        // disconnect reverts back in state
        IInitialized Disconnect();
        // methods only available when connected
        bool GetValue(string name);
        void SetValue(string name, bool value);
    }
