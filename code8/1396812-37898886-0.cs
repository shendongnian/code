      set
      {
        if (value == null)
          value = "";
        if (value == this.Text)
          return;
        if (this.CacheTextInternal)
          this.text = value;
        this.WindowText = value;
        this.OnTextChanged(EventArgs.Empty);
        if (!this.IsMnemonicsListenerAxSourced)
          return;
        for (Control control = this; control != null; control = control.ParentInternal)
        {
          Control.ActiveXImpl activeXimpl = (Control.ActiveXImpl) control.Properties.GetObject(Control.PropActiveXImpl);
          if (activeXimpl != null)
          {
            activeXimpl.UpdateAccelTable();
            break;
          }
        }
      }
