    public ProgressSpinner()
    {
       InitializeComponent();
       // make the clicks on the picturebox invoke the click event
       // on our control
       Loading_pb.Click += (o,e) => { this.OnClick(e); }
    }
