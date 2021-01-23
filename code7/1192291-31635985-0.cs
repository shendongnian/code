    toggle.onValueChanged.AddListener(MyListener);//Do this in Start() for example
    
    public void MyListener()
    {
     if(toggle.isOn)
        {
        //do the stuff when the toggle is on
        }else {
        //do the stuff when the toggle is off
        }
    
    }
