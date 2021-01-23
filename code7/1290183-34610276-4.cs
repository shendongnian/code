    public interface IReport { ICollection<IColumn> Columns { get; set; } }
    public interface IColumn { ICollection<Value> Values { get; set; } }
    public interface IValue<T> where T: IConvertible { T Data { get; set; } }
    public abstract class Value
    {
        public string FormatString { protected get; set; }
        protected abstract string AsFormattedString();
        public override string ToString() { return AsFormattedString(); }
    }
