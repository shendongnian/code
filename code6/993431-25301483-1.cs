    public interface ItemViewModel<out T> where T:IEntity
    {
        T Model { get; }
    }
    public class BuildingItemViewModel : ItemViewModel<Building>
    {
        Building b;
        private BuildingItemViewModel(Building b) { this.b = b; }
        public Building Model { get { return b; } }
    }
