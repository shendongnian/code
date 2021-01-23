        [Localizable(true)]
        [PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
        [WebCategory("Appearance")]
        [WebSysDescription("MaskBase_Text")]
        [Bindable(true, BindingDirection.TwoWay)]
        [DefaultValue("")]
            public string Text {
            get {
                string item = (string)this.ViewState["Text"];
                if (item != null) {
                    return item;
                }
                return string.Empty;
            }
            set {
                this.ViewState["Text"] = value;
            }
        }
