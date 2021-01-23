     CQ HtmlContainingImg = html;
        foreach (var img in HtmlContainingImg["IMG"])
           {
             string imgsrc = img.Attributes["src"];
             if (!IsAbsoluteUrl(imgsrc))
               {
      img.Attributes["src"]= Setting.FelApplicationPath + Setting.folderPath + imgsrc;
                 }
           }
     html=  HtmlContainingImg.Render(); // I was missing this line
