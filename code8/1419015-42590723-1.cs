    public class NgByRepeaterFinder : By
        {
            public NgByRepeaterFinder(string locator)
            {
                FindElementsMethod = context => context.FindElements(NgBy.Repeater(locator));
            }
        }
    
        internal class NgByModelFinder : By
        {
            public NgByModelFinder(string locator)
            {
                FindElementMethod = context => context.FindElement(NgBy.Model(locator));
            }
        }
