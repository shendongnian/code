    public class ColumnTextElementHandler : IElementHandler
    {
        public ColumnTextElementHandler(ColumnText ct)
        {
            this.ct = ct;
        }
        ColumnText ct = null;
        public void Add(IWritable w)
        {
            if (w is WritableElement)
            {
                foreach (IElement e in ((WritableElement)w).Elements())
                {
                    ct.AddElement(e);
                }
            }
        }
    }
