    [CodedUITest]
    public class TestingClass
    {
        WpfWindow containingWindow;
        [TestInitialize]
        public void Initialize()
        {
            this.containingWindow = ApplicationUnderTest.Launch(appPath);
        }
        [TestMethod]
        public void Test1()
        {
            WpfListItem toClick = new WpfListItem(this.containingWindow);
            // look in the UI map to see what it is doing for search properties
            // and take the simplest sub-set that makes sense
            toClick.SearchProperties.Add("AutomationId", "SomeId");
            Mouse.Click(toClick); // do not need point, typically
           /*
           //You may need to include more levels of searching,
           //but you can see what you need from the UI Map
           WpfTable table = new WpfTable(this.containingWindow);
           table.SearchProperties.Add("AutomationId", "myTableId");
           WpfListViewItem itemToClick = new WpfListViewItem(table);
           itemToClick.SearchProperties.Add("Name", "Some name");
           */
        }
    }
