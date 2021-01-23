    public Window1()
        {
            InitializeComponent();
            MyInfo myinfo = new MyInfo();
            myinfo.name = name.Content.ToString();
            myinfo.ssn = ssn.Content.ToString();
            myinfo.dob = dob.Content.ToString();
        }
