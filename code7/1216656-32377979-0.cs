    namespace LinkApplication
    {
    	public interface IEventReceiver
    	{
    		void Receive<T>(T arg) where T : EventArgs;
    	}
    
    	public class SomeUniqueEvent : EventArgs
    	{
    		public bool Clicked { get; set; }
    
    		public SomeUniqueEvent(bool clicked)
    		{
    			Clicked = clicked;
    		}
    	}
    
    	public static class EventTunnel
    	{
    		private static readonly List<IEventReceiver> _receivers = new List<IEventReceiver>();
    		public static void Publish<T>(T arg) where T : EventArgs
    		{
    			foreach (var receiver in _receivers)
    			{
    				receiver.Receive(arg);
    			}
    		}
    
    		public static void Subscribe(IEventReceiver subscriber)
    		{
    			_receivers.Add(subscriber);
    		}
    	}
    }
    
    namespace ProjectClick
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    
    			try { InitializeComponent(); }
    			catch (Exception e)
    			{
    				Console.WriteLine(e.InnerException);
    			}
    		}
    		private void Button_Click(object sender, RoutedEventArgs e)
    		{
    			LinkApplication.EventTunnel.Publish(new LinkApplication.SomeUniqueEvent(true));
    		}
    		private void Button_Leave(object sender, RoutedEventArgs e)
    		{
    			LinkApplication.EventTunnel.Publish(new LinkApplication.SomeUniqueEvent(false));
    		}
    	}
    }
    
    namespace ProjectUser
    {
    
    	public partial class MainWindow : Window, LinkApplication.IEventReceiver, INotifyPropertyChanged
    	{
    
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			this.WindowStartupLocation = WindowStartupLocation.CenterScreen; //start the window at the centre of the screen
    			DataContext = this;
    			LinkApplication.EventTunnel.Subscribe(this);
    
    		}
    
    		public bool CompareClick { get; set; }
    
    		public bool ClickCheck
    		{
    			get { return CompareClick; }
    			set
    			{
    				if (value != CompareClick)
    				{
    					CompareClick = value;
    					OnPropertyChanged("ClickCheck");
    				}
    			}
    		}
    
    		public void Receive<T>(T arg) where T : EventArgs
    		{
    			var casted = arg as SomeUniqueEvent;
    			if (casted != null)
    			{
    				ClickCheck = casted.Clicked;
    			}
    		}
    
    		public event PropertyChangedEventHandler PropertyChanged;
    	}
    }
