        /*
         *  Method used for get map of element and it's children
         *  element - element whose children you want to explore
         *  comma - use empty string - ""
        */
        public void getMap(WpfControl element, String comma)
        {
            comma = comma + "\t";
            foreach (Object child in element.GetChildren())
            {
                WpfControl childAsWpf = child as WpfControl;
                if (childAsWpf != null && !(element is WpfListItem))
                {
                    logElementInfo(childAsWpf, comma);
                    getMap(childAsWpf, comma);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("--------- object: {0}; type: {1}", child, child.GetType());
                }
            }
        }
        // logs element info in Output
        private void logElementInfo(WpfControl element, String comma)
        {
            System.Diagnostics.Debug.WriteLine("{0}AutomationId: {1}, ClassName: {2}, ControlType: Wpf{3}", comma, element.AutomationId, element.ClassName, element.ControlType);
        }
