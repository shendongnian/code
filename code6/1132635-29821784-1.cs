    public interface IMultiSegmentBase { }
    internal class MultiSegmentBase : IMultiSegmentBase {}
    public abstract class E7XGroupBase
    {
        protected abstract IMultiSegmentBase GroupSegment { get; }
    }
