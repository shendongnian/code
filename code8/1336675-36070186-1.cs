    using Widgets;
    namespace Client
    {
        public class Client
        {
            public static void Main(string[] args)
            {
                IWidget blueWidget = new WidgetFactory().BuildBlue();
                IWidget otherBlueWidget = new BlueWidget(); // doesn't compile
            }
        }
    }
