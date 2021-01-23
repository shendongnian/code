    public MainWindow()
    {
       InitializeComponent();
       FillListView();
    }
    private void FillListView()
    {
       List<MChiStructure> coll = new List<MChiStructure>();
       for (int start = 0; start < 10; start++)
       {
          coll.Add(new MChiStructure()
          {
              TitleField = "Your Title: " + start.ToString(),
              chiV1Minus = start - 1,
              chiV1Plus = start + 1,
              mV1Plus = start - 1
          });
       }
       listView.ItemsSource = coll;
    }
