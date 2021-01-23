    static int DoSomething(string s, int t)
        {
            Console.WriteLine(s+t.ToString());
            return 0;
        }// this is the delegate method, you can define it anyway.
    public delegate int MyDelegate(string s, int t);
    MyDelegate x = new MyDelegate(DoSomething);
    AsyncCallback callback = new AsyncCallback(CallBack);
    var argumentsObj=new ArgumentObject{ A="argument1", B="argument2"..};
    IAsyncResult ar = x.BeginInvoke("hello", 12, callback, argumentsObj);
    // in my case, the first two parameters are not important, only the last two are important.
