    public virtual string Text {
        get {
            if (CacheTextInternal) {
                return(text == null) ? "" : text;
            }
            else {
                return WindowText;
            }
        }
        set {
            if (value == null) {
                value = "";
            }
            if (value == Text) {
                return;
            }
            if (CacheTextInternal) {
                text = value;
            }
            WindowText = value;
            OnTextChanged(EventArgs.Empty);
            if( this.IsMnemonicsListenerAxSourced ){
                for( Control ctl = this; ctl != null; ctl = ctl.ParentInternal ) {
                    ActiveXImpl activeXImpl = (ActiveXImpl)ctl.Properties.GetObject(PropActiveXImpl);
                    if( activeXImpl != null ) {
                        activeXImpl.UpdateAccelTable();
                        break;
                    }
                }
            }
           
        }
    }
