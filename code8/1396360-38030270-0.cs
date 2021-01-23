    public class SomeMainClass{
       public void MultiCommandInit()
        {
            MultiCommand.New()
                .Add(new Command1())
                .Add(new Command2())
                .Add(new Command3())
                .SharedContext(CC => {
                    CC.Data = new RequiredData();
                    CC.ServerController = GetServerController();
                });
                
        }
        private IServerController GetServerController()
        {
            // return proper instance of server controller
            throw new NotImplementedException();
        }
    }
