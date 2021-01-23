    public void Execute(object param)
                {
                    ClientModel model= (ClientModel )param;
                    //TODO: Insert XML serialization and save to a file
                    var xml = Helper.Serialize(param);
    
    
                    //Placeholder to make sure the button works
                    viewModel.DisplayMessage = "You clicked the button at " + DateTime.Now;
                }
