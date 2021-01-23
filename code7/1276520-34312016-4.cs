        public class ExceptionHandlerMiddleware
        {
            public override async Task Invoke(IOwinContext context)
            {
                try
                {
                    await Next?.Invoke(context);
                }
                catch (Exception ex)
                {
                    // handle and/or log
                }
            }
        }
