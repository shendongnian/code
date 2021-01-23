    foreach (var control in (from c in hhScreenControls where c is MiTab select c))
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
