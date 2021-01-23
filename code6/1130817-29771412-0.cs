    Public Bubble : Panel {
    
      Public Bubble(string text) {
        Label title = new Label { Text = text };
        Controls.Add(title);
    
        Button delete = new Button { Text = "Delete" };
        Controls.Add(delete);
    
        //also hook up events here, ie delete.click+= whatever
    
      }
    
    }
