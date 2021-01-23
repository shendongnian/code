    public class MySelectionGridObject extends MonoBehaviour() {
        public Rect orientation;
        public int selectedItem;
    
        OnGUI() {
            selected = GUI.SelectionGrid(orientation, selected, ...);
        }
    }
