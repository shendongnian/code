	public class Example
	{
		private void CreateAction()
		{
			int bus = 4;
			object[] data = new object[16];
			int length = 1500;
	
			Action doWorkLater = () =>
			{
				var busCopy = bus;
				var dataCopy = data;
				var lengthCopy = length;
	
				this.WorkMethod(busCopy, dataCopy, lengthCopy);
			};
			
			doWorkLater.Invoke();
		}
	
		public void WorkMethod(int bus, object[] data, int length)
		{
		}
	}
