    @{
    // Wrong
    string bgcolor = "#" + MySpace.Common.CommonColors.MyTestColor.ToHtmlColorValue(); // no rgb parameter
   
    // correct
     string bgcolor = "#" + MySpace.Common.CommonColors.MyTestColor.ToHtmlColorValue("argument here");
    }
