    toggle.onValueChanged.AddListener((value) =>
        {
            MyListener(value);
       });//Do this in Start() for example
    
    public void MyListener(bool value)
    {
     if(value)
        {
        //do the stuff when the toggle is on
        }else {
        //do the stuff when the toggle is off
        }
    
    }
