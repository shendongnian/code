    [assembly:ExportRenderer(typeof(Project.MenuTableView), typeof(Project.Droid.MenuTableViewRenderer))]
    namespace Project.Droid
    {
        public class MenuTableViewRenderer : TableViewRenderer
        {    
            private bool _firstElementAdded = false;
    
            protected override void OnElementChanged (ElementChangedEventArgs<TableView> e)
            {
                base.OnElementChanged (e);
    
                if (Control == null)
                    return;
    
                var listView = Control as Android.Widget.ListView;    
                listView.ChildViewAdded += (sender, args) => 
                {    
                    if (!_firstElementAdded)
                    {    
                        args.Child.Visibility = ViewStates.Gone;    
                        _firstElementAdded = true;    
                    }
    
                };
                // Uncomment this if you want to remove all the dividers from the table.
                //listView.DividerHeight = 0;    
            }    
        }
    }
