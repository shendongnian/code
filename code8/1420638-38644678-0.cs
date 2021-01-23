    private void CreateAction()
    {
        int bus = 4;
        CustomObject[] data = new object[16];
        int length = 1500;
    
        var busCopy = bus; // a copy of bus
        var dataCopy = data; // this is useless
        var lengthCopy = length; // a copy of length
    
        this.doWorkLater = new Action(() =>
        {
            this.WorkMethod(busCopy, dataCopy, lengthCopy);
        });
    }
