    public class StartingDragBehavior:Behavior<ListView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.CanDragItems = true;
            this.AssociatedObject.DragItemsStarting += AssociatedObject_DragItemsStarting;
        }
        private void AssociatedObject_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            e.Data.RequestedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
            if(e.Items!=null && e.Items.Any())
            {
                e.Data.Properties.Add("item", e.Items.FirstOrDefault());
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.DragItemsStarting -= AssociatedObject_DragItemsStarting;
        }
    }
