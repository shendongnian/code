    public interface ICanContainItem
    {
        bool ContainsItem { get; }
    }
    public class Gamespace : GameObjectBase, ICanContainItem
    {
        private bool _containsItem;
        public bool ContainsItem
        {
            get { return _containsItem; }
            private set { _containsItem = value; }
        }
    }
