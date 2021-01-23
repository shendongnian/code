    private void objectListView1_CellClick(object sender, CellClickEventArgs e) {
        // check if it is the column of interest
        if (e.Column == olvColumn3) {
            // method 1: just get the value from the objectListView1 cell, 
            // this potentially requires casting ModelValue to the correct type which can be error prone if the type changes
            object value = e.SubItem.ModelValue;
                
            // method 2: since you "know" what property of your underlying model is displayed in column 3,
            // you should retrieve it directly from the model object
            MyModel modelObject = (MyModel)e.Model;
            string value2 = modelObject.ValueThatBelongsToColumn3;
        }
    }
