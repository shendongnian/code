    public class NinjectBindings : NinjectModule
    {
    	public override void Load()
    	{
    		Bind<IBillLineEntities>.To<BillLines.BillLines>().InSingletonScope();
    	}
    }
