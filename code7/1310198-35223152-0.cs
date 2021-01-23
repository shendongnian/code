    public class A
    {
        public Action doStuffDel;
        public void X()
        {
             string text = "hey";
             Expression<Action> doStuff = () => Console.WriteLine(hey);
             doStuffDel = doStuff.Compile();
        }
        public void Y()
        {
             string text = "hey 2";
             // It will still print "hey"
             doStuffDel(); // Smart or fool? ;)
        }
    }
