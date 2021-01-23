    List<MiTab> tabs = (from c in hhScreenControls where c is MiTab select c).ToList<MiTab>();
    foreach (var control in tabs)
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
