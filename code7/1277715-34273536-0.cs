    public abstract class RenderFilter
    {
        public virtual bool AllowText(TextRenderInfo renderInfo)
        {
            return true;
        }
        
        public virtual bool AllowImage(ImageRenderInfo renderInfo)
        {
            return true;
        }
    }
