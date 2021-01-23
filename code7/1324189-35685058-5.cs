    public class EndDropBehavior : Behavior<ListView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.AllowDrop = true;
            this.AssociatedObject.Drop += AssociatedObject_Drop;
            this.AssociatedObject.DragOver += AssociatedObject_DragOver;
        }
        private void AssociatedObject_Drop(object sender, Windows.UI.Xaml.DragEventArgs e)
        {
            if (e.DataView != null &&
                e.DataView.Properties != null &&
                e.DataView.Properties.Any(x => x.Key == "item" && x.Value.GetType() == typeof(MyObject)))
            {
                try
                {
                    var def = e.GetDeferral();
                    var item = e.Data.Properties.FirstOrDefault(x => x.Key == "item");
                    var card = item.Value as MyObject;
                    
                        
                        var list = sender as ListView;
                        var vm = list.DataContext as Infrastructure.ViewModels.CreditCardsViewModel;
                        
                            
                            vm.MyCollection.Add(card);
                    
                    def.Complete();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    
                }
                
            }
            else
            {
                e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
            }
        }
        private void AssociatedObject_DragOver(object sender, Windows.UI.Xaml.DragEventArgs e)
        {
            if (e.DataView != null &&
                e.DataView.Properties != null &&
                e.DataView.Properties.Any(x => x.Key == "item" && x.Value.GetType() == typeof(MyObject)))
            {
                e.AcceptedOperation = e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
            }
            else
            {
                e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Drop -= AssociatedObject_Drop;
            this.AssociatedObject.DragOver -= AssociatedObject_DragOver;
        }
    }
