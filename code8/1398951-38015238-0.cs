        public override async ArasReturnTypeItem LoginAsync()
		{
    #if __MOBILE__
			bool isMobile = true;
			if (isMobile)
			{
				throw new NotSupportedException("Windows authentication is not supported in mobile version");
			}
    #endif
            //some async code
        }
