    public sealed partial class MainPage : Page
    {
        private List<Item> items;
        public MainPage()
        {
            items = new List<Item>()
            {
                new Item() { Title = "3D Build", Headline="MS Corp" },
                new Item() { Title = "7Zip", Headline="Igor Pavlov" },
                new Item() { Title = "Photoshop", Headline = "Adobe"}
            };
            this.InitializeComponent();
        }
        public List<Item> Items { get { return items; } }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lv = sender as ListView;
            if (e.RemovedItems.Count > 0)
            {
                foreach (var item in e.RemovedItems)
                {
                    var container = lv.ContainerFromItem(item) as ListViewItem;
                    var panel = container.ContentTemplateRoot as EditablePanel;
                    panel.SetInViewMode();
                }
            }
            if (e.AddedItems.Count > 0)
            {
                foreach (var item in e.AddedItems)
                {
                    var container = lv.ContainerFromItem(item) as ListViewItem;
                    var panel = container.ContentTemplateRoot as EditablePanel;
                    panel.SetInEditMode();
                }
            }
        }
    }
    public class Item
    {
        public string Title { get; set; }
        public string Headline { get; set; }
    }
