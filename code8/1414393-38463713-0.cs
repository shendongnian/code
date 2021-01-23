    namespace Tracer
    {
        using System;
        using System.Runtime.CompilerServices;
        sealed class CallerInfoTracer : IDisposable
        {
            private readonly string _message;
            private readonly string _memberName;
            private readonly string _sourceFilePath;
            private readonly int _lineNumber;
    
            private bool _disposed;
    
            public CallerInfoTracer(string message, [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int lineNumber = 0)
            {
                _message = message;
                _memberName = memberName;
                _sourceFilePath = sourceFilePath;
                _lineNumber = lineNumber;
            }
            public void Dispose()
            {
                if (_disposed) return;
    
                Console.WriteLine("Message: {0}", _message);
                Console.WriteLine("MemberName: {0}", _memberName);
                Console.WriteLine("SourceFilePath: {0}", _sourceFilePath);
                Console.WriteLine("LineNumber: {0}", _lineNumber);
                _disposed = true;
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Method1();
                Method2();
            }
            public static void Method1()
            {
                using (var tracer = new CallerInfoTracer("Desc1")) { }
            }
            public static void Method2()
            {
                using (var tracer = new CallerInfoTracer("Desc2")) { }
            }
        }
    }
