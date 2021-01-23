    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    public class Once : IDisposable
    {
        HashSet<Tuple<string,int>> passed;
        public Once(){
            passed = passed.New();
        }
        public bool Do(Expression<Action> act,
            [CallerFilePath] string file = "",
            [CallerLineNumber] int line = 0
        ){
            if(act != null){
                var id = Tuple.Create(file,line);
                if(!passed.Contains(id)){
                    act.Compile().Invoke();
                    passed.Add(id);
                    return true;
                }
            }
            return false;
        }
        void IDisposable.Dispose() {
            passed.Clear();
        }
    }
