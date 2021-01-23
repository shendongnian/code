    [Export(typeof(ISaveAndLoadState))]
    public class iAmAPluginViewModelOrModule : ISaveAndLoadState
    
    public class StateManager : IStateManager
    {
        [ImportMany(typeof(ISaveAndLoadState))]
        private List<ISaveAndLoadState> _saveAndLoadStates;
    }
