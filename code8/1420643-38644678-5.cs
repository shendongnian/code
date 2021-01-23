    private void CreateAction()
    {
        int bus = 4;
        CustomObject[] data = new object[16];
        int length = 1500;
    
        var busCopy = bus; // a copy of bus
        var dataCopy = data; // reference copy
        var lengthCopy = length; // a copy of length
    
        this.doWorkLater = new Action(() =>
        {
            this.WorkMethod(busCopy, dataCopy, lengthCopy);
        });
        bus = 10; // No effect on the action
        length = 1700; // No effect on the action
        this.doWorkLater();
    }
