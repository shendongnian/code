    public class MyTabControl : TabControl
    {
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
      public new TabPage SelectedTab {
        get { return base.SelectedTab;  }
        set { base.SelectedTab = value; }
      }
    }
