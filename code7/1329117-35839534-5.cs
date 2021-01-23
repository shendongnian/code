    foreach (var control in hhScreenControls.OfType<MiTab>())
    {
       var tab = control as MiTab;
       if (tab != null)
       {
          foreach (var tabControl in tab.Controls)
          {
             ....
          }
       }
    }
