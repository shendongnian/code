        // There are many possible strategies for generating IDs unique within the page. 
        //For example, based on an index corresponding to the current file record.
        var fileIdx = 0;
        foreach (string strfile in Directory.GetFiles(Server.MapPath("~/images")))
        {
            ImageButton imageButton = new ImageButton(){ ID = "imageBtn" + fileIdx++ };
            FileInfo fi = new FileInfo(strfile);
            imageButton.ImageUrl = "~/images/" + fi.Name;
            imageButton.Height = Unit.Pixel(100);
            imageButton.Style.Add("padding", "5px");
            imageButton.Width = Unit.Pixel(100);
            imageButton.Click += new ImageClickEventHandler(imageButton_Click);
            AMSPanel1.Controls.Add(imageButton);
            AMSPanel1.Height=Unit.Pixel(860);
 
            UpdatePanel1.Triggers.Add(new AsyncPostBackTrigger { 
                                        ControlID = imageButton.ID,
                                        EventName = "imageButton_Click"
                                      });
        }
