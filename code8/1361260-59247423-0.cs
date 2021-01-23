    using System;
    using System.Runtime.CompilerServices;
    
    namespace SO_36796820
    {
        public class OutOfScopeEvent
        {
            public string MethodName { get; set; }
            public int StackLevel { get; set; }
        }
    
        public delegate void NotifyInScope(OutOfScopeEvent obj);
        public delegate void NotifyOutOfScope(OutOfScopeEvent obj);
        
        public class OutOfScopeToken : IDisposable
        {
            private readonly string _methodName;
            public event NotifyOutOfScope NotifyOutOfScope;
            private readonly int _stackLevel;
            
            public OutOfScopeToken(string methodName = "", int stackLevel = 0)
            {
                _methodName = methodName;
                _stackLevel = stackLevel;
            }
            
            public void Dispose()
            {
                NotifyOutOfScope?.Invoke(new OutOfScopeEvent() { MethodName = _methodName, StackLevel = _stackLevel - 1});
            }
        }
    
        public class OutOfScope : IDisposable
        {
            private readonly OutOfScopeToken _outOfScopeToken;
            
            public event NotifyOutOfScope NotifyOutOfScope;
            public event NotifyInScope NotifyInScope;
    
            private int _stackLevel = 0;
            
            public OutOfScope()
            {
                NotifyOutOfScope += OnOutOfScope;
            }
    
            public OutOfScopeToken GetToken([CallerMemberName] string methodName = nameof(GetToken))
            {
                NotifyInScope?.Invoke(new OutOfScopeEvent()
                {
                    MethodName = methodName,
                    StackLevel = _stackLevel
                });
                _stackLevel++;
                var outOfScopeToken = new OutOfScopeToken(methodName, _stackLevel);
                outOfScopeToken.NotifyOutOfScope += NotifyOutOfScope;
                return outOfScopeToken;
            }
    
            private void OnOutOfScope(OutOfScopeEvent obj)
            {
                _stackLevel--;
            }
    
            public void Dispose()
            {
                _outOfScopeToken?.Dispose();
            }
        }
        
        class Program
        {
            private static OutOfScope _outOfScope;
            static void a()
            {
                using var v = _outOfScope.GetToken();
                b();
                c();
            }
    
            static void b()
            {
                using var v = _outOfScope.GetToken();
            }
    
            static void c()
            {
                using var v = _outOfScope.GetToken();
                d();
            }
    
            static void d()
            {
                using var v = _outOfScope.GetToken();
            }
            
            static void Main(string[] args)
            {
                _outOfScope = new OutOfScope();
                _outOfScope.NotifyOutOfScope += OutOfScope;
                _outOfScope.NotifyInScope += InScope;
                a();
            }
    
            private static void InScope(OutOfScopeEvent obj)
            {
                Console.WriteLine(new String('\t', obj.StackLevel) + " I'm in " + obj.MethodName);
            }
    
            private static void OutOfScope(OutOfScopeEvent obj)
            {
                Console.WriteLine(new String('\t', obj.StackLevel) + " I'm out of " + obj.MethodName);
            }
        }
    }
