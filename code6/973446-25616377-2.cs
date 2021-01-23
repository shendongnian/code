    foreach (var x in searchs)
            {
                
                Info info = new Info();
                info.key = key;
                info.id = x._id;
                try
                {
                    var list = Api.Info(info);
                    
                }
                catch (Exception exe)
                {
 
                }
            }
