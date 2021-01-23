    //define aspect to log method call
    public class Logging : IAspect
    {
        //define method name console log with additional whatever information if defined.
        public IEnumerable<IAdvice> Advise(MethodInfo method)
        {
            //get year attribute
            var year = method.GetCustomAttributes(typeof(YearAttribute)).Cast<YearAttribute>().FirstOrDefault();
            
            if (year == null)
            {
                yield return Advice.Basic.After(() => Console.WriteLine(methode.Name));
            }
            else //Year attribute is defined, we can add whatever information to log.
            {
                var whatever = year.whatever;
                yield return Advice.Basic.After(() => Console.WriteLine("{0}/whatever={1}", method.Name, whatever));
            }
        }
    }
    public class A
    {
        [Year(whatever = 2.0)]
        public void SampleMethod()
        {
        }
    }
    //Attach logging to A class.
    Aspect.Weave<Logging>(method => method.ReflectedType == typeof(A));
    //Call sample method
    new A().SampleMethod();
    //console : SampleMethod/whatever=2.0
