    public MainWindow()
    {
        InitializeComponent();
        this.tabControl1.MouseClick += tabControl1_MouseClick;
    }
    void tabControl1_MouseClick(object sender, MouseEventArgs e)
    {
       if (e.Button == MouseButtons.Right)
       {
           for (int i = 0; i < tabControl1.TabCount; i++)
           {
               if (tabControl1.GetTabRect(i).Contains(e.Location))
               {
                   Console.WriteLine("Right Cliked on tab {0}", i);
               }
           }             
       }
    }
