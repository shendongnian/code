    namespace POCOs
    {
    	using System.Collections.Generic;
    	using System.ComponentModel;
    	using System.Runtime.CompilerServices;
    
    	public class Appliance : INotifyPropertyChanged
    	{
    		private int id;
    		public int Id { get { return id; } set { SetPropertyValue(ref id, value); } }
    		private string name;
    		public string Name { get { return name; } set { SetPropertyValue(ref name, value); } }
    		private int top;
    		public int Top { get { return top; } set { SetPropertyValue(ref top, value); } }
    		private int left;
    		public int Left { get { return left; } set { SetPropertyValue(ref left, value); } }
    		private int width;
    		public int Width { get { return width; } set { SetPropertyValue(ref width, value); } }
    		private int height;
    		public int Height { get { return height; } set { SetPropertyValue(ref height, value); } }
    		private int type;
    		public int Type { get { return type; } set { SetPropertyValue(ref type, value); } }
    		private int color;
    		public int Color { get { return color; } set { SetPropertyValue(ref color, value); } }
    		private bool visible;
    		public bool Visible { get { return visible; } set { SetPropertyValue(ref visible, value); } }
    		protected void SetPropertyValue<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
    		{
    			if (EqualityComparer<T>.Default.Equals(field, value)) return;
    			field = value;
    			OnPropertyChanged(propertyName);
    		}
    		public event PropertyChangedEventHandler PropertyChanged;
    		protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
    		{
    			var handler = PropertyChanged;
    			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }
 
