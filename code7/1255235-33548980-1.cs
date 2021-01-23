    var listView = new CustomListView();
    listView.Clear();
    public class CustomListView : ListView
    {
        public new void Clear()
        {
            Console.WriteLine("I can clear myself...");
        }
    }
