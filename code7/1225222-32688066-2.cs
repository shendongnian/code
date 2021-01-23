    public class DropArea : ContentControl
        [...]
        public DropArea()
        {
            DragEnter += AssociatedObjectDragEnter;
            DragLeave += AssociatedObjectDragLeave;
            DragOver += AssociatedObjectDragOver;
            IsTabStop = false;
            AllowDrop = true;
        }
        protected override void AssociatedObjectDrop(object sender, DragEventArgs e)
        {
            object o = e.Data.GetData(typeof(anyKeyType));
            //handle dropped data
        }
