    public void Testing() {
        // 5 is boxed here
        var myBoxedInt = (object)5;
    
        var myInt = 4;
        // myInt is boxed and sent to the method
        SomeCall(myInt);
    }
    
    public void SomeCall(object param1){}
