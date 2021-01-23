    private readonly ObservableCollection<PointViewModel> midPoints
        = new ObservableCollection<PointViewModel>();
   
    public ObservableCollection<PointViewModel> MidPoints
    {
        get { return midPoints; }
    }
    public void UpdateMidPoints()
    {
        // performs calculations that add and remove elements to/from midPoints
        // ...
    }
