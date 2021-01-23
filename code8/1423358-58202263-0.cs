        private void DisposeSpecFlowContext()
        {
            try
            {
                var disposableContext = ScenarioContext.Current as IDisposable;
                disposableContext.Dispose();
            }
            catch
            {
            }
        }
