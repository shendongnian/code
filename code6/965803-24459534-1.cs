    public DataModel Clone() {
        return new DataModel() {
            PropertyA = this.PropertyA,
            PropertyB = this.PropertyB,
            //etc.
        }
    }
    //OR - Without a clone method:
    newUserControl.NewDataModel = new DataModel()
    {
        PropertyA = oldUserControl.OldDataModel.PropertyA,
        PropertyB = oldUserControl.OldDataModel.PropertyB,
        //etc
    }
