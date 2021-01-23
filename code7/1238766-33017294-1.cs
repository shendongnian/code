    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    
    namespace Sandbox.Behaviors
    {
       public sealed class VerticalOffsetBehaviour : Behavior<ScrollViewer>
       {
          public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(VerticalOffsetBehaviour), new PropertyMetadata(VerticalOffsetBehaviour.OnValueChanged));
    
          public double Value
          {
             get { return (double)this.GetValue(ValueProperty); }
             set { this.SetValue(ValueProperty, value); }
          }
    
          private static void OnValueChanged(object source, DependencyPropertyChangedEventArgs args)
          {
             var behavior = (VerticalOffsetBehaviour)source;
             behavior.AssociatedObject.ScrollToVerticalOffset(behavior.Value);
          }
       }
    }
