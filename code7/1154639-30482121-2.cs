        kernel.Bind<IService>().To<ReadonlyService>()
          .When(r => 
               {
                   // return false if not injected into User
                   if (r.Target == null)
                   {
                       return false;
                   }
                   if(!typeof(User)
                      .IsAssignableFrom(r.Target.Member.ReflectedType))
                   {
                       return false;
                   }
       
                   return HttpContext.Current.Request.HttpMethod == "GET";
               });
