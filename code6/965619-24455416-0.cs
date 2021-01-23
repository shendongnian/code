    Type classType = this.GetType();
    object obj = Activator.CreateInstance(classType)
    object[] parameters = new object[] { _objval };
    MethodInfo mi = classType.GetMethod("MyMethod");
    ThreadStart threadMain = delegate () { mi.Invoke(this, parameters); };
    new System.Threading.Thread(threadMain).Start();
