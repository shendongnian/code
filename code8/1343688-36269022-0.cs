    public void MyCheckbox_Event(object sender, EventArgs e){
        var chk = sender as CheckBox;
        if(chk == null) return;
        string name = chk.Name;
        switch(name){
            case "name1":
            //do something for name 1
            break;
            case "name2":
            //do something for name 2
            break;
            //and so on and so forth
        }
    
    }
