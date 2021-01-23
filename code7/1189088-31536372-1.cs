    public Form1()
    {
         InitializeComponent();
         CheckBox[] chk = new CheckBox[10];
         for (int i = 0; i < 10; i++)
         {
             chk[i] = new CheckBox();
             chk[i].Name = "Polygon " + i + 1;
             //Rest of your code
         }
    }
