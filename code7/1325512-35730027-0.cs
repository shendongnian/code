    public class ClipStorageCollection : System.Collections.ObjectModel.ObservableCollection<Clip>
    {
        public ClipStorageCollection(IEnumerable<Clip> clips)
            : base(clips)
        {
        }
    }
