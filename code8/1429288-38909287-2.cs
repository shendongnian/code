    IEnumerable< HtmlButton> btns = buttonContainer.Controls.OfType<HtmlButton>();
    if(btns != null)
    {
         //get only the ones that have a special class to know which ones you need to update
         var btnList = btns.Where(x => x.Attributes["class"] == "save-button");
         //update the text for all that passed the filter
         foreach(HtmlButton ctrl in btnList)
         {
            ctrl.InnerText = "Save Me";
         }
    }
