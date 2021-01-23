    private PowerPoint.Slide Sld;
    public PowerPoint.Slide Slide
    {
       get {return Sld;}
       set {this.Sld = value; RaisePropertyChanged(() => Slide);}  
    }
