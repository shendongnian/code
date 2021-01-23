    public abstract class BaseChart
    {
        public void Zoom()
        {
            if (Series != null)
            {
                OnZoom();
            }
        }
        protected abstract void OnZoom();
        public virtual void DrawChart()
        {
        }
        protected abstract object Series { get; }
        public virtual void GetPoints()
        {
        }
    }
    public class FastChart : BaseChart
    {
        private readonly BoxTypeFirst BTF = new BoxTypeFirst();
        protected override void OnZoom()
        {
            throw new System.NotImplementedException();
        }
        protected override object Series
        {
            get { return BTF.AreaSeries; }
        }
    }
    public class SlowChart : BaseChart
    {
        private readonly BoxTypeFirst BTF = new BoxTypeFirst();
        protected override void OnZoom()
        {
            throw new System.NotImplementedException();
        }
        protected override object Series
        {
            get { return BTF.CandleStickSeries; }
        }
    }
