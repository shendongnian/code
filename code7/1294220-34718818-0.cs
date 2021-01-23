    public void Test()
    {
        var enumeratorParameter 
            = Expression.Parameter(typeof(IEnumerator<string>), "enumerator");
    
        var sampleEnumMethod = typeof(SampleExpression).GetMethod("SampleEnum");
        var methodCall = Expression.Call(sampleEnumMethod, enumeratorParameter);
    
        var e = Expression.Lambda<Func<IEnumerator<string>, string>>
                  (
                    methodCall, 
                    enumeratorParameter
                  );
        
        var lstConstant = "1,2,3,4,".Split(',');
        e.Compile()(lstConstant.ToList().GetEnumerator());
    }
    
    class SampleExpression
    {
        public static string SampleEnum(IEnumerator<string> ien)
        {
            while (ien.MoveNext())
            {
                Console.WriteLine(ien.Current);
            }
            
            return "Done!";
        }
    }
