        public Form1()//in the constructor of your form
        {
            InitializeComponent();
            TabPage add = new TabPage("+");
            tabControll.TabPages.Add(add);
            tabControll.SelectedIndexChanged += delegate
            {
                if (tabControll.SelectedTab == add)
                {
                    var index = tabControll.TabPages.Count - 1;
                    var myNewTab = new TabPage("title");
                    //what ever you want to do with the tab
                    tabControll.TabPages.Insert(index, myNewTab);
                    tabControll.SelectedTab = myNewTab;
                }
            };
        }
