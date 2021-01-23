        [ Category("Behavior"),
        Description("The subscriptions collection"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
          PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        public List<Subscription> SubscriptionList { 
         get
            {
                if (lists == null)
                {
                    lists = new List<Subscription>();
                }
                return lists;
            }
        }
