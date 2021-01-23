    private async void myButtonItem_Clicked(object sender, EventArgs e)
    		{
    			Core.Service.AtmisService service = new Core.Service.AtmisService();
    			LoginResponse loginTask = await service.Login(userName.Text, password.Text).ConfigureAwait(false);
                //The rest of the code in this method may run in a different thread than the one that invoked this handler.
    		}
