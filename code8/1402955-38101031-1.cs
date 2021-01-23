    public List<string> mainList;
        public List<SubItem> secondList, thirdList;
        public BlankPage1()
        {
            this.InitializeComponent();
            mainList = new List<string>();
            mainList.Add("Main Item 1");
            mainList.Add("Main Item 2");
            mainList.Add("Main Item 3");
            mainList.Add("Main Item 4");
            mainList.Add("Main Item 5");
            secondList = new List<SubItem>();
            secondList.Add(new SubItem { mainItem = "Main Item 1", subItem = "Second Item 1" });
            secondList.Add(new SubItem { mainItem = "Main Item 1", subItem = "Second Item 2" });
            secondList.Add(new SubItem { mainItem = "Main Item 1", subItem = "Second Item 3" });
            secondList.Add(new SubItem { mainItem = "Main Item 2", subItem = "Second Item 1" });
            secondList.Add(new SubItem { mainItem = "Main Item 2", subItem = "Second Item 2" });
            secondList.Add(new SubItem { mainItem = "Main Item 2", subItem = "Second Item 3" });
            secondList.Add(new SubItem { mainItem = "Main Item 3", subItem = "Second Item 1" });
            secondList.Add(new SubItem { mainItem = "Main Item 3", subItem = "Second Item 2" });
            secondList.Add(new SubItem { mainItem = "Main Item 3", subItem = "Second Item 3" });
            secondList.Add(new SubItem { mainItem = "Main Item 4", subItem = "Second Item 1" });
            secondList.Add(new SubItem { mainItem = "Main Item 4", subItem = "Second Item 2" });
            secondList.Add(new SubItem { mainItem = "Main Item 4", subItem = "Second Item 3" });
            secondList.Add(new SubItem { mainItem = "Main Item 5", subItem = "Second Item 1" });
            secondList.Add(new SubItem { mainItem = "Main Item 5", subItem = "Second Item 2" });
            secondList.Add(new SubItem { mainItem = "Main Item 5", subItem = "Second Item 3" });
            thirdList = new List<SubItem>();
            thirdList.Add(new SubItem { mainItem = "Second Item 1", subItem = "Third Item 1" });
            thirdList.Add(new SubItem { mainItem = "Second Item 1", subItem = "Third Item 2" });
            thirdList.Add(new SubItem { mainItem = "Second Item 1", subItem = "Third Item 3" });
            thirdList.Add(new SubItem { mainItem = "Second Item 1", subItem = "Third Item 4" });
            thirdList.Add(new SubItem { mainItem = "Second Item 2", subItem = "Third Item 1" });
            thirdList.Add(new SubItem { mainItem = "Second Item 2", subItem = "Third Item 2" });
            thirdList.Add(new SubItem { mainItem = "Second Item 2", subItem = "Third Item 3" });
            thirdList.Add(new SubItem { mainItem = "Second Item 2", subItem = "Third Item 4" });
            thirdList.Add(new SubItem { mainItem = "Second Item 3", subItem = "Third Item 1" });
            thirdList.Add(new SubItem { mainItem = "Second Item 3", subItem = "Third Item 2" });
            thirdList.Add(new SubItem { mainItem = "Second Item 3", subItem = "Third Item 3" });
            thirdList.Add(new SubItem { mainItem = "Second Item 3", subItem = "Third Item 4" });
            _one.ItemsSource = mainList;
        }
        public class SubItem
        {
            public string mainItem { get; set; }
            public string subItem { get; set; }
        }
        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Main Item is clicked
            //To show Second Item list
            TextBlock tb = sender as TextBlock;
            List<string> seconditems = new List<string>();
            foreach(SubItem s in secondList)
            {
                if(s.mainItem == tb.Text)
                {
                    seconditems.Add(s.subItem);
                }
            }
            this._two.ItemsSource = seconditems;
            this._two.UpdateLayout();
            //In case the user clicks the Main Item when already Third list has items
            _three.ItemsSource = null;
            this._three.UpdateLayout();
            //Set OpenPaneLength manually so Items look nice
            MySplitView.OpenPaneLength = _one.Width + _two.Width + 50;
            this.MySplitView.UpdateLayout();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //To Open Close SplitView
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void TextBlock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            // Secondary Item is clicked
            // To show thirdlist
            TextBlock tb = sender as TextBlock;
            List<string> thirditems = new List<string>();
            foreach (SubItem s in thirdList)
            {
                if (s.mainItem == tb.Text)
                {
                    thirditems.Add(s.subItem);
                }
            }
            this._three.ItemsSource = thirditems;
            this._three.UpdateLayout();
            //Set OpenPaneLength manually so Items look nice
            MySplitView.OpenPaneLength = _one.Width + _two.Width + _three.Width+ 50;
            this.MySplitView.UpdateLayout();
        }
