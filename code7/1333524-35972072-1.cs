    private ObservableCollection<PointViewModel> midPoints;
   
    public ObservableCollection<PointViewModel> MidPoints
    {
        get { return midPoints; }
        set
        {
             midPoints = value;
             OnPropertyChanged("MidPoints");
         }
     }
     public void UpdateMidPoints()
     {
         ObservableCollection<PointViewModel> newMidPoints = new ObservableCollection<PointViewModel>();
         // 
         // calculations...
         //
         MidPoints = newMidPoints;
     }
