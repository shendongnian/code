    public class ScriptExecutor<TP, TR> : CrossAppDomainObject, IScriptExecutor<TP, TR>
    {
        private readonly Script<TR> _script;
        private int _currentClients;
        public DateTime TimeStamp { get; }
        public int CurrentClients => _currentClients;
        public string Script => _script.Code;
        public ScriptExecutor(string script, DateTime? timestamp = null, bool eagerCompile = false)
        {
            if (string.IsNullOrWhiteSpace(script))
                throw new ArgumentNullException(nameof(script));
            
            var opts = ScriptOptions.Default.AddImports("System");
            _script = CSharpScript.Create<TR>(script, opts, typeof(Host<TP>)); // Other options may be needed here
            if (eagerCompile)
            {
                var diags = _script.Compile();
                Diagnostic firstError;
                if ((firstError = diags.FirstOrDefault(d => d.Severity == DiagnosticSeverity.Error)) != null)
                {
                    throw new ArgumentException($"Provided script can't compile: {firstError.GetMessage()}");
                }
            }
            if (timestamp == null)
                timestamp = DateTime.UtcNow;
            TimeStamp = timestamp.Value;
        }
        public void Execute(TP parameters, RemoteCompletionSource<TR> completionSource)
        {
            Interlocked.Increment(ref _currentClients);
           _script.RunAsync(new Host<TP> {Args = parameters}).ContinueWith(t =>
           {
               if (t.IsFaulted && t.Exception != null)
               {
                   completionSource.SetException(t.Exception.InnerExceptions.ToArray());
                   Interlocked.Decrement(ref _currentClients);
               }
               else if (t.IsCanceled)
               {
                   completionSource.SetCanceled();
                   Interlocked.Decrement(ref _currentClients);
               }
               else
               {
                   completionSource.SetResult(t.Result.ReturnValue);
                   Interlocked.Decrement(ref _currentClients);
               }
           });
        }
    }
    public class Host<T>
    {
        public T Args { get; set; }
    }
