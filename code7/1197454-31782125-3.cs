	public TextBoxViewModel: IControlViewModel
	{
		...
        public object OutputValue
        {
            get 
            {   
                //return whatever is your expected output value from control
                return Value; 
            }
        }
        ...
	}
