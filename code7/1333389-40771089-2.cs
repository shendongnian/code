        override Advice Advise(Type type, MethodInfo method)
        {
            //type is the supposed intercepted type.
            //method is the supposed intercepted method.
        
            //this block of code means that method will be rewrite to execute a write method name to console before original code only for public methods
            if (method.IsPublic)
            {
                return new Before(() => Console.WriteLine(method.Name));
            }
            else
            {
                return null;
            }
        }
    }
    var aspect = new MyAspect();
    //attach myaspect to A class. All methods of A will be passed to Advise method to process methods rewriting.
    aspect.Manage<A>();
    //detach myaspect from A class. all methods will be rewrite to give back original code.
    aspect.Dispose<A>();
