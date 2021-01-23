    public Engine Change()
    {
        return new Engine
        { 
            PropertyA = this.PropertyA,
            PropertyB = this.PropertyB + 1,
            PropertyC = this.PropertyC,
        };
    }
