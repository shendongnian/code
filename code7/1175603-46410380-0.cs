    Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
    if(oXL.Version.Equals("15.0"))
    {
       //bla bla..
    }
    else if(oXL.Version.Equals("14.0")||oXL.Version.Equals("12.0") || oXL.Version.Equals("11.0"))
    {
       //bla bla..
    }
