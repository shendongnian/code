    public Form3()
    {
         InitializeComponent();
         Panel panel1 = new Panel();
         Label[] lblArr = new Label[100];//Use any control you want
         int y = 10;
         for (int i = 0; i < 100; i++)
         {
             lblArr[i] = new Label();
             lblArr[i].Text = "lbl" + i;
             lblArr[i].Location = new Point(30, y);
             panel1.Location = new Point(0, 0);
             panel1.Size = new Size(600, 2500);
             panel1.Controls.Add(lblArr[i]);
             y += 25;
         }
         this.Controls.Add(panel1); 
    }  
