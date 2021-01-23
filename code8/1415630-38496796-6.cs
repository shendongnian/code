    private int _ID;
    private bool _IsEngagedwithWork;
    public int ID { 
         get { return _ID}; 
         set {
           _ID = value;
           OnPropertyChanged(()=>ID );
           notifyMe = managerList.FirstOrDefualt(m => m.ID == _ID);
           if (notifyMe != null) { notifyMe.NotifyChanged()}
         } 
    }
    public bool IsEngagedwithWork { 
           get { return _IsEngagedwithWork ;} 
           set {
                 _IsEngagedwithWork = value;
                 OnPropertyChanged(()=>IsEngagedwithWork );
                 notifyMe = managerList.FirstOrDefualt(m => m.ID == _ID);
                 if (notifyMe != null) { notifyMe.NotifyChanged()}
           } 
}
