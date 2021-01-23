     public static void RunLocked<T>(Func<T> objCreator, Action<T> run, string LockName)
        where T:IDisposable
     {
        lock(getlockobject(LockName))
        {
            using(var obj = objCreator())
            {
                run(obj);
            }
        }
     }
