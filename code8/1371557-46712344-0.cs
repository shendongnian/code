    [TestMethod]
    public void LineNumberInStackTrace()
    {
        try
        {
            var result = CSharpScript.EvaluateAsync<int>(
                @"string s = null; 
    // some comment at line 2
    var upper = s.ToUpper(); // Null reference exception at line 3
    // more code", ScriptOptions.Default.WithEmitDebugInformation(true)).Result;
        }
        catch (AggregateException e)
        {
            if (e.InnerException is NullReferenceException inner)
            {
                var startIndex = inner.StackTrace.IndexOf(":line ", StringComparison.Ordinal) + 6;
                var lineNumberStr = inner.StackTrace.Substring(
                    startIndex, inner.StackTrace.IndexOf("\r", StringComparison.Ordinal) - startIndex);
                var lineNumber = Int32.Parse(lineNumberStr);
                Assert.AreEqual(3, lineNumber);
                return;
            }
        }
        Assert.Fail();
    }
    [TestMethod]
    public void LineNumberNotInStackTrace()
    {
        try
        {
            var result = CSharpScript.EvaluateAsync<int>(
                @"string s = null; 
    // some comment at line 2
    var upper = s.ToUpper(); // Null reference exception at line 3
    // more code").Result;
        }
        catch (AggregateException e)
        {
            if (e.InnerException is NullReferenceException inner)
            {
                var startIndex = inner.StackTrace.IndexOf(":line ", StringComparison.Ordinal);
                    
                Assert.AreEqual(-1, startIndex);
                return;
            }
        }
        Assert.Fail();
    }
