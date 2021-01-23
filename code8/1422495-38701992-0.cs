    private List<Item> itemsList = null;
    
            public Form1()
            {
                InitializeComponent();
                Load += OnLoad;
            }
    
            private async void OnLoad(object sender, EventArgs eventArgs)
            {
                itemsList = await dataContext.Items.Where(x => x.Active == true).ToListAsync();
            }
