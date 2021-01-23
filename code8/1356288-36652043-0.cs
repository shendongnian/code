    public class MyCollectionEditor : CollectionEditor
    {
        public MyCollectionEditor() : base(typeof(Collection<Point>)) { }
        protected override CollectionForm CreateCollectionForm()
        {
            var form = base.CreateCollectionForm();
            // Other Settings
            // ...
            form.StartPosition = FormStartPosition.Manual;
            form.DesktopLocation = new Point(10, 10);
            return form;
        }
    }
