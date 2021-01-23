    class Bar
    {
        public static void Main(string[] args)
        {
            TestWindow Window = new TestWindow(800, 600);
            Window.ShowDialog();
        }
    }
    class TestWindow : Form
    {
        public TestWindow(int Width, int Height)
        {
            Size = new Size(Width, Height);
            BackColor = Color.Black;
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MyDataGrid = new DataGrid();
            MyDataGrid.Size = new Size(400, 200);
            MyDataGrid.DataSource = new List<DummyData> { new DummyData("AB", "AD", "AI"), new DummyData("XB", "XS", "XI"), new DummyData("UUU", "FFF", "DDD"), new DummyData("XXXX", "UUUU", "IIII") };
            Button ShowCellButton = new Button();
            ShowCellButton.Click += new EventHandler(MyButton_Click);
            ShowCellButton.Location = new Point(700, 100);
            ShowCellButton.Text = "Show Text";
            ShowCellButton.ForeColor = Color.White;
            ShowCellButton.FlatStyle = FlatStyle.Flat;
            Controls.Add(MyDataGrid);
            Controls.Add(ShowCellButton);
        }
        DataGrid MyDataGrid;
        public void MyButton_Click(object sender, EventArgs e)
        {
            string Text = GetCellText(ref MyDataGrid, 2, 3); // Get Text in Column 2 and Row 3
            MessageBox.Show(Text.ToString());
        }
        public struct DummyData
        {
            public DummyData(string _Key, string _Value, string _Pair)
            {
                Key = _Key;
                Value = _Value;
                Pair = _Pair;
            }
            public string this[int Index]
            {
                get
                {
                    if (Index == 0)
                        return Key;
                    if (Index == 1)
                        return Value;
                    if (Index == 2)
                        return Pair;
                    return "";
                }
                set
                {
                    if (Index == 0)
                        Key = value;
                    if (Index == 1)
                        Value = value;
                    if (Index == 2)
                        Pair = value;
                }
            }
            public string Key { get; set; }
            public string Value { get; set; }
            public string Pair { get; set; }
        }
        private string GetCellText(ref DataGrid MyDataGrid, int Column, int Row)
        {
            List<DummyData> MyData = (List<DummyData>)MyDataGrid.DataSource;
            string ReturnValue = "";
            for (int i = 0; i < MyData.ToArray().Length; i++)
            {
                DummyData Temp = MyData[Row - 1];
                return (Temp[Column - 1]);
            }
            return (ReturnValue);
        }
    }
