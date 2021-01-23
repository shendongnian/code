    <Grid>
       <EmailView Visibility= "{Binding ControlVisibility}" />
    </Grid>
    
    public ICommand EmailPopUpCmd { get; set; }
    private void EmailPopUp(object sender) {
        ControlVisibility = Visible;
     }
     private Visibility _controlVisibility = Collapsed;
     public Visibility ControlVisibility
     {
        get
        {
           return _controlVisibility;
        }
        set
        {
            _controlVisibility = value;
            OnPropertyChanged("ControlVisibility");
        }
     }
