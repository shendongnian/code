    public static GridView BuildChatsGrid()
    {
        GridView NewDg = new GridView();
    
        NewDg.Columns.Add(new BoundField { DataField = "Message", HeaderText = "Note" });
        //NewDg.Columns.Add(new BoundField { DataField = "SenderDetails", HeaderText = "Entered By" });  //need item template
        NewDg.Columns.Add(GetTemplateField("SenderDetails")); //Newly addded
        NewDg.Columns.Add(new BoundField { DataField = "SentDate", HeaderText = "Date", DataFormatString = "{0:dd/MM/yyyy}" });
    }
