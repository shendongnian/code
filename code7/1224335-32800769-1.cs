    using (var ctx = new TestEntities()) {
         ctx.Configuration.LazyLoadingEnabled = false;                
         ctx.Configuration.ProxyCreationEnabled = false;                
         var code = ctx.Codes.First();                
         var error = ctx.Errors.First();
         Debug.Assert(Object.ReferenceEquals(error.Code, code));                                
    }
