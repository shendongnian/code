    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace Sandbox
    {
        public partial class MainWindow
        {
            public List<Item> Items { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                Items = new List<Item>
                {
                    new Item { Id = 1, Name = "First" },
                    new Item { Id = 2, Name = "Second" },
                    new Item { Id = 3, Name = "Third" },
                    new Item { Id = 4, Name = "Fourth" },
                };
            }
    
            private void UIElement_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                var dataGrid = FlipView.SelectedItem as DataGrid;
                if (dataGrid == null) return;
                if (!dataGrid.SelectedCells.Any()) return;
                var args = new KeyEventArgs(
                    Keyboard.PrimaryDevice,
                    Keyboard.PrimaryDevice.ActiveSource,
                    0,
                    e.Key);
                args.RoutedEvent = Keyboard.KeyDownEvent;
                dataGrid.RaiseEvent(args);
                e.Handled = true;
            }
    
            public class Item
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
        }
    }
