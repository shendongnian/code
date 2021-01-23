    using (var rep = new efEntities()){
         var results= rep.Genre.ToList();
         // bind
         DropDownList1.datasource=results;
         DropDownList1.DataTextField="";
         DropDownList1.DataValueField="";
         DropDownList1.DataBind();
    }
    protected void DropDownList1_selectedindexChanged(){
        int genreID = convert.toint32(DropDownList1.selectedvalue);
        // search database
        using (var rep = new efEntities()){
        var results = rep.Music.Where(m=>m.genreID==genreID).ToList();
        // loop to get results
        foreach(var item in results){
            //do stuff
    }
    }
    }
