	public class MyViewModel 
	{
		public ICommand LoginCommand{get; private set;}
		
		public MyViewModel
		{
			LoginCommand = new RelayCommand(_ => DoSomething );
		}
		
		public void DoSomething(object obj)
        {
            MessageBox.Show(obj.ToString());
        }
	}
