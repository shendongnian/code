    public class MenuElement
    {
        public MenuElement(string text, int height, int width, Action<object> myMethod)
        {
            DoAction = myMethod;
        }
        public Action<object> DoAction { get; private set; }
    }
            MenuElement m1 = new MenuElement("text", 10, 20, (obj) => { Console.WriteLine("MenuElement1"); });
            m1.DoAction(null);
            Action<object> y = (obj) =>
            {
                Console.WriteLine("MenuElement2");
            };
            MenuElement m2 = new MenuElement("text", 10, 20, y);
            m2.DoAction(null); // calls y()
