    public class MyAspect : Aspect
    {
        //this method is called initially (not on interception) to rewrite method body.
        override protected IEnumerable<Advice<T>> Advise<T>(MethodInfo method)
        {
            //this block of code means that method will be rewrite to execute a write method name to console before original code only for public methods
            if (method.IsPublic)
            {
                yield return Advice<T>.Basic.Before(() => Console.WriteLine(method.Name));
            }
        }
    }
    var aspect = new MyAspect();
    //attach myaspect to A class. All methods of A will be passed to Advise method to process methods rewriting.
    aspect.Manage<A>();
    //detach myaspect from A class. All methods will be rewrite to give back original code.
    aspect.Dispose<A>();
