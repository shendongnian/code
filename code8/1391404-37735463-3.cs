    private IEnumerable<string> Test()
    {
        using (TestClass t = new TestClass())
        {
            try
            {
                System.Diagnostics.Debug.Print("1");
                yield return "1";
                System.Diagnostics.Debug.Print("2");
                yield return "2";
                System.Diagnostics.Debug.Print("3");
                yield return "3";
                System.Diagnostics.Debug.Print("4");
                yield return "4";
            }
            finally
            {
                System.Diagnostics.Debug.Print("Finally");
            }
        }
    }
    
    private class TestClass : IDisposable
    {
        public void Dispose()
        {
            System.Diagnostics.Debug.Print("Disposed");
        }
    }
