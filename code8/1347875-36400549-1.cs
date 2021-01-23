	public Form1()
	{
	  InitializeComponent();
	  ElementHost host= new ElementHost();
	  host.Size = new Size(200, 100);
	  host.Location = new Point(100,100);
	  UserControlDLL.MyUserControl edit = new UserControlDLL.MyUserControl();
	  host.Child = edit;
	  this.Controls.Add(host);
	}
