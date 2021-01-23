    public static class Debug
    {
        public static void WriteLine(string str)
        {
            var sf = new StackFrame(1,true);
            System.Diagnostics.Debug.WriteLine("{0}({1}): {2}",
                Path.GetFileName(sf.GetFileName()),
                sf.GetFileLineNumber(),
                str
            );
        }
    }
