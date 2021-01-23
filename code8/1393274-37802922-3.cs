           Site site = _server.Sites[name];
           if (site == null)
             return;
    
           var bindings = site.Bindings.ToList();
           
           foreach (Binding binding in bindings)
           {
              site.Bindings.Remove(binding, true);
           }
              _server.Sites.Remove(site);
    
              _server.CommitChanges();
        
