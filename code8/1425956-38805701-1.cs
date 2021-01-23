    public class InventoriableComponentList<T> : System.Collections.Generic.List<T>
        where T : Component, IInventoriable {
        public InventoriableComponentList()
            : base {
        }
        public InventoriableComponentList(IEnumerable<T> collection)
            : base(collection) {
        }
    }
