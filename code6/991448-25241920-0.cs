	public class MyClass
	{
		private int _index;
		public MyClass(int i)
		{
			_index = i;
		}
		public void OpenAbitmap()
		{
			Bitmap picture = new Bitmap(@"C:\Users\Desktop\A\" + _index.ToString() + ".bmp");
		}
	}
