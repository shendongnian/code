    public class MyCollectionEditor:CollectionEditor
    {
        public MyCollectionEditor()
            : base(typeof(Collection<MyElement>))
        {}
        protected override CollectionForm CreateCollectionForm()
        {
            var form =  base.CreateCollectionForm();
            var grid = form.Controls.Find("propertyBrowser",true).First() as PropertyGrid;
            var menu = new ContextMenuStrip();
            menu.Items.Add("Reset...", null, (s, e) => { grid.ResetSelectedProperty(); });
            grid.ContextMenuStrip = menu;
            return form;
        }
    }
