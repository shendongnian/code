        private static readonly string _helloScript =
              "print(\"Hello World!\")"
            ;
        public void LoadScripts(IDatabase db, IServer srv)
        {
            var scripts = new Dictionary<string, string>
            {
                { "sayHello",                      _helloScript },
            };
            foreach (var scriptName in scripts.Keys)
            {
                var prepped = LuaScript.Prepare(scripts[scriptName]);
                _scripts.Add(scriptName, prepped.Load(srv));
            }
        }
        public void SayHello(IDatabase db)
        {
            _scripts["sayHello"].Evaluate(db);
        }
