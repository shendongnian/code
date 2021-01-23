    public abstract class ViewModelBase : IScreen
    {
            //sealed so the users of the viewmodelbase cannot accidentally override it
            public async override sealed void CanClose(Action<bool> callback)
            {
                callback(await CanClose());
            }
    
            //default implementation is always closable
            public async virtual Task<bool> CanClose()
            {
                return true;
            }
    
    }
