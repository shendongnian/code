    private bool _visibleProp;
    public bool VisibleProp{get{return _visibleProp;} 
        set{_visibleProp = value; 
            if(value){var storyboard = this.Resources["open"] as Storyboard;
                    storyboard.Begin(); }
            else{var storyboard = this.Resources["close"] as Storyboard;
                    storyboard.Begin();}
              }}
