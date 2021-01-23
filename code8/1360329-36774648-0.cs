    public class MyMefClassImplementation : IMyMefClass
    {
        public void Start()
        {
            try
            {
                await SomeAsyncMethod();
            } catch(Exception ex) {
                throw ex
            }
        }
        // ...
    }
