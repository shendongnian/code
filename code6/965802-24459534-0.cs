    public DataModel Clone() {
        return new DataModel() {
            PropertyA = this.PropertyA,
            PropertyB = this.PropertyB,
            //etc.
        }
    }
