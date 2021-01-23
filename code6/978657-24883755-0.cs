        public override void DataBind()
        {
            foreach (var item in (IEnumerable<LifestreamItem>)this.DataSource)
            {
                if (item is LifestreamTwitterItem)
                {
                    TwitterTemplate.InstantiateIn(item); // instantiate inside the item which is also a control.
                }
                else
                {
                    ItemTemplate.InstantiateIn(item);
                }
                item.DataBind(); // bind the item
                Controls.Add(item); // add the item to the repeater
            }
        }
