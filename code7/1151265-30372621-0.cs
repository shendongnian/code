     System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
        createDiv.Style.Add("float", "left");
        System.Web.UI.HtmlControls.HtmlImage img =
            new System.Web.UI.HtmlControls.HtmlImage();
        img.Src = "Your source code.";
        img.Border = 0;
        img.Style.Add("width", "80px");
        img.Style.Add("margin-right", "10px");
        img.Style.Add("margin-bottom", "10px");
        createDiv.Controls.Add(img);
        tstPanel.Controls.Add(createDiv);
