    void writeResults()
    {
    DataTable dt = new DataTable();
    dt.Columns.Add("configID");
    dt.Columns.Add("configValue");
    //Other code you want to add
    //Then add row for each setting
    Datarow r  = dt.NewRow();
    r["configID"]= "Speed"; //e.g. Speed  
    r["configValue"]=_timer.Interval.ToString();  
    dt.Rows.Add(r);
    // snip
    //then save datatable to file
    dt.TableName="UserConfigs";
    dt.WriteXml(@"filename_goes_here");
    }
