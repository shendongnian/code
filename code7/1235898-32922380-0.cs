    private void Form1_Load(object sender, EventArgs e)
    {
        KeyPreview = true;
        FillLV(10);
        AddPBs(36);
        listView1.MouseMove += listView1_MouseMove;
    }
    void FillLV(int count)
    {
        for (int i = 0; i < count; i++) listView1.Items.Add("Item" + i, i);
    }
    void AddPBs(int count)
    {
        int iWidth = imageList1.ImageSize.Width;
        int iHeight = imageList1.ImageSize.Height;
        int cols = panel1.ClientSize.Width / iWidth;
        for (int i = 0; i < count; i++)
        {
            PictureBox PB = new PictureBox();
            PB.BackColor = Color.LightGray;
            PB.Margin = new System.Windows.Forms.Padding(0);
            PB.ClientSize = new System.Drawing.Size(64, 64);
            PB.Parent = panel1;
            PB.DragEnter += PB_DragEnter;
            PB.DragDrop += PB_DragDrop;
            PB.AllowDrop = true;
            PB.MouseClick += (ss, ee) => { currentPB = PB; PB.Focus(); };
            PB.Location = new Point(iWidth * (i % cols), iHeight * (i / cols));
        }
    }
