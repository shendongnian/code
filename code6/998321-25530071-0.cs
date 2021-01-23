    public class OverflowVisibilityBehavior : Behavior<VirtualizingStackPanel>
    {
      protected override void OnAttached()
      {
        AssociatedObject.LayoutUpdated += AssociatedObject_LayoutUpdated;
        base.OnAttached();
      }
    
      protected override void OnDetaching()
      {
        AssociatedObject.LayoutUpdated -= AssociatedObject_LayoutUpdated;
      }
    
      void AssociatedObject_LayoutUpdated(object sender, EventArgs e)
      {
        var parent = AssociatedObject; //that solves the problem: you can get a "sender" information
        
        //...
        // Instead of property GetValue
        (VisualTreeHelper.GetParent(parent) as ItemsPresenter).ActualHeight
      }
    }
