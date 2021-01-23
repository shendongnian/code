    public class Aroon : IndicatorCalculatorBase
    {
        public override List<OhlcSample> OhlcList { get; set; }
        private readonly int _period;
        public int Period
        {
            get { return _period; }
        }
        public Aroon(int period)
        {
            _period = period;
        }
        public override IIndicatorSerie Calculate()
        {
            var aroonSerie = new AroonSerie();
            for (var i = _period; i < OhlcList.Count; i++)
            {
                var aroonUp = CalculateAroonUp(i);
                var aroonDown = CalculateAroonDown(i);
                aroonSerie.Down.Add(aroonDown);
                aroonSerie.Up.Add(aroonUp);
            }
            return aroonSerie;
        }
        private double CalculateAroonUp(int i)
        {
            var maxIndex = FindMax(i - _period, i);
            var up = CalcAroon(i - maxIndex);
            return up;
        }
        private double CalculateAroonDown(int i)
        {
            var minIndex = FindMin(i - _period, i);
            var down = CalcAroon(i - minIndex);
            return down;
        }
        private double CalcAroon(int numOfDays)
        {
            var result = ((_period - numOfDays)) * ((double)100 / _period);
            return result;
        }
        private int FindMin(int startIndex, int endIndex)
        {
            var min = double.MaxValue;
            var index = startIndex;
            for (var i = startIndex; i <= endIndex; i++)
            {
                if (min < OhlcList[i].Low)
                    continue;
                min = OhlcList[i].Low;
                index = i;
            }
            return index;
        }
        private int FindMax(int startIndex, int endIndex)
        {
            var max = double.MinValue;
            var index = startIndex;
            for (var i = startIndex; i <= endIndex; i++)
            {
                if (max > OhlcList[i].High)
                    continue;
                max = OhlcList[i].High;
                index = i;
            }
            return index;
        }
    }
    public abstract class IndicatorCalculatorBase
    {
        public abstract List<OhlcSample> OhlcList { get; set; }
        public abstract IIndicatorSerie Calculate();
    }
    public interface IIndicatorSerie
    {
        List<double> Up { get; }
        List<double> Down { get; }
    }
    internal class AroonSerie : IIndicatorSerie
    {
        public List<double> Up { get; private set; }
        public List<double> Down { get; private set; }
        public AroonSerie()
        {
            Up = new List<double>();
            Down = new List<double>();
        }
    }
    public class OhlcSample
    {
        public double High { get; private set; }
        public double Low { get; private set; }
        public OhlcSample(double high, double low)
        {
            High = high;
            Low = low;
        }
    }
