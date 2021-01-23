    internal class Program
    {
        private static void Main(string[] args)
        {
            var engine = new Engine(c => c.AllowClr(typeof (JsTimer).Assembly))
                .SetValue("log", new Action<object>(Console.WriteLine))
                .Execute(
                    @" 
    var callback=function(){
       log('js');
    }
    var Tools=importNamespace('JsTools');
    var t=new Tools.JsTimer();
    t.OnTick(callback);
    t.Start(0,1000);
    ");
            Console.ReadKey();
        }
    }
