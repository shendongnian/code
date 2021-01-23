    public class ItemGenerator
        {
            private readonly string[] items = {"item1", "item2", "item3"};
    
            public void AddItems(ListBox listBox)
            {
                foreach (var item in items)
                {
                    listBox.Items.Add(item);
                }
            }
        }
