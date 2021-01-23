    public void SelectDevice()
    		{
    			string[] readerNames = new string[1];
    			using (var context = new SCardContext())
    			{
    				context.Establish(SCardScope.System);
    				readerNames = context.GetReaders();
    			}
    			readername = readerNames[0];
    			this.RdrState.RdrName = readername;
    		}
