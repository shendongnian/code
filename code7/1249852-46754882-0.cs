    protected override void OnParentSet()
            {
                object view = Parent;
                base.OnParentSet();
    
                if (view.GetType() == typeof(Grid))
                {
                    
                }
            }
