    public class SomeFunctionExecutor<TType> : ISomeFunctionExecutor
    {
        public void Execute(SomeContext context)
        {
            var data = context.GetStorage<TType>().Cast<IEntityWithSomeFunction>();
            foreach (var item in data)
            {
                item.SomeFunction();
            }
        }
    }
