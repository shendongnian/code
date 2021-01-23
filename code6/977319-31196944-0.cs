    interface ISynchronizationContext
    {
        System.Threading.SynchronizationContext ViewContext { get; set; }
    } 
    (this.DataContext as ISynchronizationContext).ViewContext  = 
    (SynchronizationContext)Dispatcher.Invoke
    (new Func<SynchronizationContext>(() => SynchronizationContext.Current));
