    namespace WpfApplication1.Properties
    {
    	using System.Globalization;
    	using System.ComponentModel;
    	using System.Runtime.CompilerServices;
    	using Properties;
    
    	public class ResourceService : INotifyPropertyChanged
    	{
    		#region singleton members
    
    		private static readonly ResourceService _current = new ResourceService();
    		public static ResourceService Current
    		{
    			get { return _current; }
    		}
    		#endregion
    
    		readonly Properties.Resources _resources = new Properties.Resources();
    
    		public Properties.Resources Resources
    		{
    			get { return this._resources; }
    		}
    
    		#region INotifyPropertyChanged members
    
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    		{
    			var handler = this.PropertyChanged;
    			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    		}
    
    		#endregion
    
    		public void ChangeCulture(string name)
    		{
    			Resources.Culture = CultureInfo.GetCultureInfo(name);
    			this.RaisePropertyChanged("Resources");
    		}
    	}
    }
