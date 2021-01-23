    public class DragBehavior : Behavior<FrameworkElement>
        [...]
        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            AssociatedObject.MouseDown += AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseLeave += AssociatedObject_MouseLeave;
            base.OnAttached();
        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            AssociatedObject.MouseDown -= AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseLeave -= AssociatedObject_MouseLeave;
            base.OnDetaching();
        }
        protected virtual void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (some condition of mouse button states or mouse moves)
            {
                    DataObject data = new DataObject();
                    data.SetData(typeof(anyKeyType), anyData);
                    data.SetData(typeof(anyOtherKeyType), anyOtherData);
                    DragDrop.DoDragDrop(fe, data, DragDropEffects.Move);                
            }
        }
