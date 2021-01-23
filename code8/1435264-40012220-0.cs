    Panes panes = win.Panes;
       foreach(Pane pane in panes){
           pane.Activate(); // Activate the Pane                                  
           Range r = pane.Document.Range(400, 405); // Sample range for testing                         
           r.Select();
        }
