    Frame currentFrame{get{return Window.Current.Content as Frame;}}
    
 
       public RelayCommand<OOrderM> SelectedOrderCommand{
    get
        {
    return _slectedOrderCommand??new RelayCommand<object>((itemParam)=>
    {
        currentFrame.Navigate(typeof(myPage));
    })
    };
    }
