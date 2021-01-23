        public class ClosableTabItem : TabItem
        {
        	public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(ClosableTabItem), new PropertyMetadata(null));		
        	public ICommand CloseCommand
        	{
        	  get { return (ICommand)GetValue(CloseCommandProperty); }
        	  set { SetValue(CloseCommandProperty, value); }
        	}
        }  
