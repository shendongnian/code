    public void MyMethod( ... ) {
    
        // some stuff
    
        // instead of this
        // using(...){ /* your code here */ }
    
        // you can use this
        var timebox = new Timebox(TimeSpan.FromSeconds(1));
        timebox.Execute(() =>
        {
            /* your code here */
        });
    
        // some more stuff
    
    }
