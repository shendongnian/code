    public enum ColumnType
    {
        String,
        Date,
        Currency
    }
    public interface IValue
    {
        void Parse(object obj);
    }
    public class Sheet
    {
        public List<Column> Columns { get; set; }
        public Column this[int column] { get { return Columns[column]; } set { Columns[column]=value; } }
    }
    public class Column
    {
        public string Name { get; set; }
        public ColumnType Type { get; set; }
        public List<Cell> Rows { get; set; }
        public Cell this[int row] { get { return Rows[row]; } set { Rows[row]=value; } }
    }
    public class Cell
    {
        public Column Column { get; set; }
        public IValue Data { get; set; }
    }
    public class StringValue : IValue
    {
        public StringValue(string value) { Value=value; }
        public string Value { get; set; }
        public void Parse(object obj)
        {
            Value=obj.ToString();
        }
    }
    public class DecimalValue : IValue
    {
        public DecimalValue(decimal value) { Value=value; }
        public decimal Value { get; set; }
        public void Parse(object obj)
        {
            if(obj is decimal)
            {
                Value=(decimal)obj;
            }
        }
    }
    public class DateValue : IValue
    {
        public DateValue(DateTime value) { Value=value; }
        public DateTime Value { get; set; }
        public void Parse(object obj)
        {
            if(obj is DateTime)
            {
                Value=(DateTime)obj;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sheet=new Sheet() { Columns = new List<Column>() };
            sheet.Columns.Add(new Column()
            {
                Type=ColumnType.String,
                Name="Item",
                Rows=new List<Cell>()
            });
            sheet.Columns.Add(new Column()
            {
                Type=ColumnType.Date,
                Name="Date",
                Rows=new List<Cell>()
            });
            sheet.Columns.Add(new Column()
            {
                Type=ColumnType.Currency,
                Name="Amount",
                Rows=new List<Cell>()
            });
            sheet[0].Rows.Add(new Cell() { Column=sheet[0], Data=new StringValue("AAB") });
            sheet[0].Rows.Add(new Cell() { Column=sheet[0], Data=new StringValue("AAC") });
            sheet[0].Rows.Add(new Cell() { Column=sheet[0], Data=new StringValue("ABA") });
            sheet[1].Rows.Add(new Cell() { Column=sheet[1], Data=new DateValue(DateTime.Now) });
            sheet[1].Rows.Add(new Cell() { Column=sheet[1], Data=new DateValue(DateTime.Now) });
            sheet[1].Rows.Add(new Cell() { Column=sheet[1], Data=new DateValue(DateTime.Now) });
            sheet[2].Rows.Add(new Cell() { Column=sheet[2], Data=new DecimalValue(1000m) });
            sheet[2].Rows.Add(new Cell() { Column=sheet[2], Data=new DecimalValue(1200m) });
            sheet[2].Rows.Add(new Cell() { Column=sheet[2], Data=new DecimalValue(870m) });
            sheet[0][1].Data.Parse("CCC");
            var check=(sheet[0][1].Data as StringValue).Value;
            // check == "CCC"
        }
    }
