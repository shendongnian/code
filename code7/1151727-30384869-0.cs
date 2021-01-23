    [TestMethod]
    public void AsyncMethodWithoutAsyncSuffixAnalyzer_WithAsyncKeywordAndNoSuffix_InvokesWarning()
    {
        var original = @"
    using System;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
       class MyClass
       {   
           async Task Method()
           {
               
           }
       }
    }";
    
        var result = @"
    using System;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
       class MyClass
       {   
           async Task MethodAsync()
           {
               
           }
       }
    }";
    
    	var expectedDiagnostic = new DiagnosticResult
    	{
    		Id = AsyncMethodWithoutAsyncSuffixAnalyzer.DiagnosticId,
    		Message = string.Format(AsyncMethodWithoutAsyncSuffixAnalyzer.Message, "Method"),
    		Severity = EmptyArgumentExceptionAnalyzer.Severity,
    		Locations =
    		new[]
    		{
    			new DiagnosticResultLocation("Test0.cs", 10, 13)
    		}
    	};
    
    	VerifyCSharpDiagnostic(original, expectedDiagnostic);
    	VerifyCSharpFix(original, result);
    }
