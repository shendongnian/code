    public class TileViewModel : ReactiveObject
    {
        string name;
        public string Name {
            get { return name; }
            set { this.RaiseAndSetIfChanged(ref name, value); }
        }
    }
