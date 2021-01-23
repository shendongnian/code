    public interface IReport { ICollection<IColumn> Columns { get; set; } }
    public interface IColumn { ICollection<Value> Values { get; set; } }
    public interface IValue<T> where T: IConvertible { T Data { get; set; } }
    public abstract class Value
    {
        #region Formatting
        protected IFormatProvider Formatter { get; set; }
        protected abstract IFormatProvider GetFormatter();
        protected abstract string AsFormattedString();
        public override string ToString() { return AsFormattedString(); }
        #endregion
        public Value() { Formatter = GetFormatter(); }
    }
    public abstract class Value<T>: Value, IValue<T> where T: IConvertible
    {
        #region IValue members
        public T Data { get; set; }
        #endregion
        #region Formatting
        protected override string AsFormattedString() { return Data.ToString(Formatter); }
        #endregion
    }
    public class IntValue: Value<int>
    {
        public IntValue() { }
        public IntValue(string formatstring, int data) { Formatter = new IntFormatter(formatstring); Data = data; }
        #region Formatting
        protected override IFormatProvider GetFormatter() { return new IntFormatter(); }
        internal class IntFormatter: CustomFormatter
        {
            public IntFormatter() : this("{0:#,##0;-#,##0;'---'}") { }
            public IntFormatter(string formatstring) : base(formatstring) { }
        }
        #endregion
    }
    public class DoubleValue: Value<double>
    {
        public DoubleValue() { }
        public DoubleValue(string formatstring, double data) { Formatter = new DoubleFormatter(formatstring); Data = data; }
        #region Formatting
        protected override IFormatProvider GetFormatter() { return new DoubleFormatter(); }
        internal class DoubleFormatter: CustomFormatter
        {
            public DoubleFormatter() : this("{0:0.#0;-0.#0;'---'}") { }
            public DoubleFormatter(string formatstring) : base(formatstring) { }
        }
        #endregion
    }
    public class ReportView: IReport
    {
        public ICollection<IColumn> Columns { get; set; }
        public ReportView() { Columns = new List<IColumn>(); }
    }
    public class ReportColumn: IColumn
    {
        public ICollection<Value> Values { get; set; }
        public ReportColumn() { Values = new List<Value>(); }
    }
