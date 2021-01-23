        DataGridView generate2(string name, int columns, int rows,int form)
        {
            
            Control Gen;
            Control LB;
            int x = 1;
            int runcolumn = columns;
            int runrow = rows;
            int count=0;
           
            LB = new Label();
            LB.Text = "Panel : " + name;
            LB.Location = new Point(50 + 120 / (c - 1) + 900 / c, 320);
            LB.BackColor = Color.Silver;
            Gen = new DataGridView();
            Gen.Name = name.ToString();
            Gen.Location = new Point(120 / (c) + 900 / c, 0);
            DataGridView CH = (DataGridView)Gen;
            CH.RowTemplate.Height = 290 / rows;
            CH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CH.Size = new Size(900 / c, 300);
            CH.RowHeadersWidth = 10;
            CH.ColumnHeadersHeight = 10;            
            CH.Location = new Point(0 + locate, 0);
