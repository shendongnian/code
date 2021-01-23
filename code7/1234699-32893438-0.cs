    ListBox.ObjectCollection nameList;
    DataTable dt = new DataTable();
    private int rowIndex = 0;
    private Timer timer = new Timer();
    public PopupForm(ListBox.ObjectCollection objectCollection) {
      this.InitializeComponent();
      dt.Columns.Add("List");
      myGridView.DataSource = dt;
      nameList = objectCollection;
      timer.Interval = 1000;
      timer.Tick += timer_Tick;
      timer.Start();
    }
    private void timer_Tick(object sender, EventArgs e) {
      if (rowIndex >= nameList.Count) {
        timer.Stop();
      } else {
        DataRow row = dt.NewRow();
        row[0] = nameList[rowIndex];
        dt.Rows.Add(row);
        rowIndex++;
      }
    }
