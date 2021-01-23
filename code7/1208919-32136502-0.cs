    public virtual Layout Layout { 
      get {return _layout; }
      set {
        if (IsMdiContainer) {
          foreach (MyCustomForm item in MdiChildren.Cast<MyCustomForm>()) {
            item.Layout = value;
          }
        }
        foreach (Control ctrl in Container.Controls) {
          //Apply layout settings to controls
        }
      }
