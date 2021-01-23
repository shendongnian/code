	public class Test
	{
		public bool Watch { get; set; }
		
		public Test()
		{
			this.Watch = true;
		}
		
		public void Parent()
		{
			this.Child1();
			if(this.Watch == false)
			{
				return;
			}
			this.Child2();
			if(this.Watch == false)
			{
				return;
			}
			this.Child3();
			if(this.Watch == false)
			{
				return;
			}
		}
		
		public void Child1()
		{
			//Do stuff
		}
		
		public void Child2()
		{
			this.Watch = false;
		}
		
		public void Child3()
		{
			//Do stuff
		}
	}
