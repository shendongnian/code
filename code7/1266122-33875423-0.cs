       public String LabelText{
            get {
                if (!this.Dispatcher.CheckAccess()) {
                    return (String)this.Dispatcher.Invoke(new Func<String>(() => { return LabelText; }));
                }
                return Label.Text;
            }
            set {
                if (!this.Dispatcher.CheckAccess()) {
                    this.Dispatcher.Invoke(new Action(() => { LabelText = value; }));
                    return;
                }
                LabelText = value;
            }
        }
