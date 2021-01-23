    System.Windows.Forms.TableLayoutPanel tableLayoutPanel1 = null;
    private void Form1_Load(object sender, EventArgs e)
    {
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.AutoScroll = true;
        this.tableLayoutPanel1.ColumnCount = 1;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2000));
        this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 25);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 1;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1000));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(this.Width - 50, this.Height - 80);
        this.tableLayoutPanel1.TabIndex = 21;
        this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
        this.tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.Controls.Add(this.tableLayoutPanel1);
        this.tableLayoutPanel1.BringToFront();
    }
    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {
        float virtualWidth = tableLayoutPanel1.ColumnStyles[0].Width;
        if (virtualWidth < 40000) //You can resize the area any time
        {
            tableLayoutPanel1.ColumnStyles[0].Width = 40000;
            tableLayoutPanel1.RowStyles[0].Height = 20000;
            tableLayoutPanel1.Invalidate();
            return;
        }
        e.Graphics.TranslateTransform(
            virtualWidth / 2 - tableLayoutPanel1.HorizontalScroll.Value,
            -tableLayoutPanel1.VerticalScroll.Value);
        int size = 50;
        for (int i = 0; i < 200; ++i)
        {
            for (int j = -i; j <= i; j++)
            {
                e.Graphics.DrawEllipse(Pens.Black, j * size * 2, i * size * 2, size, size);
            }
        }
    }
