    [Export(typeof(IViewModel)]
    public class SomeViewModel : IViewModel
    {
        private IStorage _storage;
        
        [ImportingConstructor]
        public SomeViewModel(IStorage storage){
            _storage = storage;
        }
        public bool ProperlyInitialized { get { return _storage != null; } }
    }
    [Export(typeof(IStorage)]
    public class Storage : IStorage
    {
        public bool SaveFile(string content){
            // Saves the file using StreamWriter
        }
    }
    //Somewhere in your application bootstrapping...
    public GetViewModel() {
         //Search all assemblies in the same directory where our dll/exe is
         string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
         var catalog = new DirectoryCatalog(currentPath);
         var container = new CompositionContainer(catalog);
         var viewModel = container.GetExport<IViewModel>();
         //Assert that MEF did as advertised
         Debug.Assert(viewModel is SomViewModel); 
         Debug.Assert(viewModel.ProperlyInitialized);
    }
