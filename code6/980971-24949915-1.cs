    public class StringProvider : Provider<string>
    {
        protected override string CreateInstance(IContext context)
        {
            return context.ToString();
        }
    }
    var kernel = new StandardKernel();
    kernel.Bind<string>().ToProvider(new StringProvider()).InSingletonScope();
    kernel.Get<string>();
    kernel.Get<string>();
    kernel.Get<string>();
