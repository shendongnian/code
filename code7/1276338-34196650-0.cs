    public class Model
	{
		public bool IsSmth { get; set; }
		public bool IsNotSmth 
		{ 
			get { return !IsSmth; }
			set { IsSmth = value; }
		}
	}
