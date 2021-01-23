    /// <summary>
    /// provide a container to display a simple KPI
    /// </summary>
    public class KPI
    {
        // props
        public string Label             { get; private set; }
        public double ValueToProcess    { get; private set; }
        public double ValueProcessed    { get; private set; }
        public string Percentage        { get; private set; }
        // default ctor
        public KPI(string label, double valueToProcess, double valueProcessed)
        {
            this.Label          = label;
            this.ValueToProcess = valueToProcess;
            this.ValueProcessed = valueProcessed;
            this.Percentage     = (valueToProcess == 0) ? "n/a" 
                                                        : String.Format("{0} %", Math.Round(ValueProcessed / ValueToProcess * 100, 2));
        }
    }
