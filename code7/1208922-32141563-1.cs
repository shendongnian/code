    public abstract class Filter
    {
        public virtual int Priority
        {
            get { return 0; }
        }
        public abstract Picture Apply(Picture picture);
    }
    public class BrightnessFilter : Filter
    {
        public override int Priority
        {
            get { return 1; }
        }
        public override Picture Apply(Picture picture)
        {
            throw new NotImplementedException();
        }
    }
    public class ContrastFilter : Filter
    {
        public override int Priority
        {
            get { return 2; }
        }
        public override Picture Apply(Picture picture)
        {
            throw new NotImplementedException();
        }
    }
