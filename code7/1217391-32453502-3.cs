    public class EntitiesViewModel {
        public EntitiesViewModel() {
            LoadEntities();
        }
        void LoadEntities() {
            Entities = new ObservableCollection<Entity>
            {
                new Entity(){ Item1="A", Item2="A0", Item3="A00"},
                new Entity(){ Item1="B", Item2="B0", Item3="B00"},
                new Entity(){ Item1="C", Item2="C0", Item3="C00"},
            };
        }
        public ObservableCollection<Entity> Entities { get; private set; }
        public virtual Entity SelectedEntity { get; set; } // Bindable property
    }
    public class Entity {
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
    }
