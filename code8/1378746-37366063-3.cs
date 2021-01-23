        [ Category("Behavior"),
        Description("The subscriptions collection"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
          PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        public List<Subscription> SubscriptionList { 
         get
            {
                object s = ViewState["SubscriptionList"];
                if ( s == null)
                {
                    ViewState["SubscriptionList"] = new List<Subscription>();
                }
                return (List<Subscription>) ViewState["SubscriptionList"];
            }
            set
            {
                ViewState["SubscriptionList"] = value;
            }
        }
