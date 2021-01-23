    namespace Widgets
    {
        public interface IWidget
        {
        }
        internal abstract class Widget : IWidget
        {
        }
        internal class BlueWidget : Widget
        {
        }
        public class WidgetFactory
        {
            public IWidget BuildBlue()
            {
                return new BlueWidget();
            }
        }
    }
