    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MyApiWebService : ClientBase<IMyApi>, IMyApi
    {
        public MyResponseContract GetFileInfo()
        {
            MyResponseContract output = null;
            using(var context = new OperationContext(Channel as IContextChannel))
            {
                output = Channel.GetFileInfo();
            }
            return output;
        }
    }
