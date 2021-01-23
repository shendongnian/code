      // set an ID explicitly for the image button
      var imageButton = new ImageButton { ID = "imageBtn"};
    
      // assumes that the ID for the update panel is 'updatePnl'
      var updatePnl = (UpdatePanel)FindControl("updatePnl");
      updatePnl.Triggers.Add(new AsyncPostBackTrigger { ControlID = imageButton.ID });
