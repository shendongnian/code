    private void CreateAction()
    {
        int bus = 4;
    
        this.doWorkLater = new Action(() =>
        {
            var busCopy = bus;
   
            this.WorkMethod(busCopy);
        });
        // if you change local `bus` before call to `doWorkLater` it will not work:
        bus = 42;
        doWorkLater(); // busCopy is 42. 
    }
