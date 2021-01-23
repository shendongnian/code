    public class HostElement : UIElement
    {
        public HostElement()
        {
            ChildElement ce;
            Int32 rows = 5;
            Int32 cols = 5;
            for (Int32 i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ce = new ChildElement();
                    this.Children.Add(ce);
                }
            }
        }
        // etc...
    }
