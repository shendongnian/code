    public class GeneralMenu : BaseMenu {
        protected override void GenerateMenu() {
            var contextMenu = new ContextMenu();
    
            contextMenu.MenuItems.Add(new MenuItem("Sort", OnSort));
            contextMenu.MenuItems.Add(new MenuItem("Print", OnPrint));
    
            _menu = contextMenu;
        }
        void OnSort(object sender, EventArgs e) {
            // do sort
        }
        void OnPrint(object sender, EventArgs e) {
            // do print
        }
    }
