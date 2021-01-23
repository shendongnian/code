    public class MyCollectionEditor : CollectionEditor
    {
        public MyCollectionEditor() : base(typeof(Collection<MyElement>)) { }
        protected override CollectionForm CreateCollectionForm()
        {
            var form = base.CreateCollectionForm();
            var grid = form.Controls.Find("propertyBrowser", true).First() as PropertyGrid;
            var menu = new ContextMenuStrip();
            menu.Items.Add("Reset", null, (s, e) => { grid.ResetSelectedProperty(); });
            //Enable or disable Reset menu based on selected property
            menu.Opening += (s, e) =>
            {
                if (grid.SelectedGridItem != null && grid.SelectedObject != null &&
                    grid.SelectedGridItem.PropertyDescriptor.CanResetValue(null))
                    menu.Items[0].Enabled = true;
                else
                    menu.Items[0].Enabled = false;
            };
            grid.ContextMenuStrip = menu;
            return form;
        }
    }
