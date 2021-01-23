    public Form1()
    {
        InitializeComponent();
        button.Parent = picturebox;
        picturebox2.Parent = button;
        picturebox.BackColor = Color.Transparent;
        button.Location = new Point(1,2);      // or whatever you want!!
        picturebox2.Location = new Point(3,4); // or whatever you want!!
     }
