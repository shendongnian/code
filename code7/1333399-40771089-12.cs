    public class MyAspect : IAspect
    {
        //this method is called initially (not on interception) to rewrite method body.
        public IEnumerable<IAdvice> Advise(MethodInfo method)
        {
            //this block of code means that method will be rewrite to execute a write method name to console before original code only for public methods
            if (method.IsPublic)
            {
                yield return Advice.Basic.Before(() => Console.WriteLine(method.Name));
            }
        }
    }
