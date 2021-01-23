    var baseObj = (System.Windows.Forms.DataObject)e.Data; 
    string sFormat = baseObj.GetFormats();
    var data = baseObj.GetData("System.String");
    
    var getInnerData = data as System.String[];
