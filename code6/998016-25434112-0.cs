          private readonly List<FormView> _foundControls = new List<FormView>();
            public IEnumerable<FormView> FoundControls
            {
                get { return _foundControls; }
            }
    
            public void FindChildControlsRecursive(Control control)
            {
                foreach (Control childControl in control.Controls)
                {
                    if (childControl.GetType() == typeof(FormView))
                    {
                        _foundControls.Add((FormView)childControl);
                    }
                    else
                    {
                        FindChildControlsRecursive(childControl);
                    }
                }
            }
    
    
     FindChildControlsRecursive(<Insert relevent Code Here: Whatever element you want to search inside of like your listView, find that using FindControl>);
                FormView[] strControl = new FormView[200];
                strControl = FoundControls.ToArray();
    
                foreach (FormView i in strControl)
                {
                    if (i.ID.Equals("< insert controlId of your FormView>"))
                    {
                        // do something when you find it
                    }
    
                }
