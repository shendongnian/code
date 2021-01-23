    public abstract class ColorHandler
    {
        public String str { get; set; }
        public int i { get; set; }
        public abstract void Handle();
        public static ColorHandler ColorHandlerFactory(String color,ref int i, ref string str)
        {
            ColorHandler handler = Handlers[color];
            handler.i = i;
            handler.str = str;
            handler.Handle();
            return handler;
        }
        public static Dictionary<String, ColorHandler> Handlers = new Dictionary<string, ColorHandler> ()
        {
            {"red",new RedHandler{myInt1 = 1,myInt2 =2,}},
            {"blue",new BlueHandler{MyStr1="str1",MyStr2="str2"} }
        };
        public Dictionary<String, ColorHandler> InitHandlers(int myNum1,int myNum2,string myStr1,string myStr2){
            return new  Dictionary<string, ColorHandler>()
        {
            {"red",new RedHandler{myInt1 = myNum1,myInt2 =myNum2}},
            {"blue",new BlueHandler{MyStr1=myStr1,MyStr2=myStr2} }
        };
        }
    }
    public class RedHandler : ColorHandler
    {
        public int myInt1 { get; set; }
        public int myInt2 { get; set; }
        public override void Handle()
        {
            this.i = myInt1+myInt2;
            // OR alternatively
            //this.myInt1 = AnExternalFunction(myInt1, myInt2);
        }
    }
    public class BlueHandler : ColorHandler
    {
        public String MyStr1 { get; set; }
        public String MyStr2 { get; set; }
        public override void Handle()
        {
            this.str = MyStr1 + MyStr2;
            // OR alternatively
            //this.myInt1 = AnExternalFunction(MyStr1, MyStr2);
        }
    }
    public class Doer
    {
        public void DoThings()
        {
            int i = 0;
            string str = string.Empty;
            var handler =ColorHandler.ColorHandlerFactory("red",ref i,ref str);
            handler.InitHandlers(1, 2, "Cat", "Dog");
            //Read Results.
            var result=handler.i;
            
        }
    }
