    private RelayCommand<MyItem> click; 
    public RelayCommand<MyItem> Click
    { 
        get
        { 
            if (click== null) 
            { 
                click= new RelayCommand<MyItem>( 
                    (item) => 
                    {                            
                        //do something with your item 
                    }); 
            }
     
            return click; 
        } 
    }
