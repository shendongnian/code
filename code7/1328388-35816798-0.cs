    private bool _myButtonIsPressed;
    public bool MyButtonIsPressed {
      get{ return _myButtonIsPressed;}
      set{
        _myButtonIsPressed = value;
        if(value==false){
          MyButton.Content = ImageWhenReleasing;
        }
        else{
          MyButton.Content = ImageWhenClicking;
        }
      }
    }
