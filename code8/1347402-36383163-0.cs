    list.Select(i => {
                       try
                       {
                           dynamic item = i;
                           return item.Prop == "value";
                       }
                       catch(RuntimeBinderException)   //this type doesn't contain the property
                       {
                           return false;
                       }
                    });
