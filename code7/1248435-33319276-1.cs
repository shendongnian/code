    public interface ISomeInterface 
    {
         string Text { get; }
    }
    
    public void HitApi<T> (ApiHandlerHelper helper)
        where T : ISomeInterface
