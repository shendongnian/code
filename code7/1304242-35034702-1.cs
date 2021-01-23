    public class GeneralMenu : BaseMenu {
        protected override void GenerateMenu() {
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Sort", OnSort));
            contextMenu.MenuItems.Add(new MenuItem("Print", OnPrint));
            _menu = contextMenu;
        }
        void OnSort(object sender, EventArgs e) {
            var gridView = GetSourceControl<DataGridView>(sender);
            if(gridView != null) {
                // do sort
            }
        }
        void OnPrint(object sender, EventArgs e) {
            var gridView = GetSourceControl<DataGridView>(sender);
            if(gridView != null) {
                // do print
            }
        }
        static TControl GetSourceControl<TControl>(object sender) where TControl : Control {
            var menu = ((MenuItem)sender).GetContextMenu();
            return (menu != null) ? menu.SourceControl as TControl : null;
        }
    }
