    public class ViewModel
    {
        public ObservableCollection<Model> Commands { get; } = new ObservableCollection<Model>
        {
            new Model { Name = "Skyrim" },
            new Model { Name = "Fallout 4" },
            new Model { Name = "Fallout NV" }
        };
    }
