    public DetailsPage()
    {
          InitializeComponent();
          TheDetailsItem = new Details ();
          this.BindingContext = TheDetailsItem;
          GetDetails ();
    }
