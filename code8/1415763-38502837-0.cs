    MvxCommand _myAwesomeCommand;
    
    		public IMvxCommand MyAwesomeCommand
    		{
    			get { return new MvxCommand(DoStuff); }
    		}
    
    		void DoStuff()
    		{
    			string test = string.Empty;
    		}
