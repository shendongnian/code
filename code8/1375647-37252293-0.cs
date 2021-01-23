    public class MinMaxVisibilityBehavior : Behavior<ScrollBar>
    {
        public override void OnAttached()
        {
            DependencyPropertyDescriptor
                    .FromProperty(ScrollBar.MaximumProperty, typeof(ScrollBar))
                    .AddValueChanged(AssociatedObject, CheckMinMax);
            DependencyPropertyDescriptor
                    .FromProperty(ScrollBar.MinimumProperty, typeof(ScrollBar))
                    .AddValueChanged(AssociatedObject, CheckMinMax);
        }
    
        private void CheckMinMax(object sender, EventArgs e)
        {
           AssociatedObject.Visibility = AssociatedObject.Minimum == 
              AssociatedObject.Maximum ? Visibility.Hidden : Visibility.Visible;
        }
    }
