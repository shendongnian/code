    public static class Test
    {
        public static IColumn Select<TResult>(this IColumn source, Func<object, TResult> selector)
        {
            throw new NotImplementedException();
        }
        public static IColumn SelectOtherColumn<TResult>(this IColumn source, Func<IColumn, TResult> selector)
        {
            throw new NotImplementedException();
        }
    }
    public interface IColumn
    {
        string Text { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            IEnumerable ojb = new object[0];
            IEnumerable<dynamic> dynX = ojb.Cast<dynamic>();
            // CS1061 'object' does not contain a definition for 'Text'...
            // var tooltip shows IColumn instead of IEnumerable<dynamic>
            //NB this is the System.Linq.Select
            var result = dynX.Select(x => x.Text);
            var xzy = dynX as IColumn;
            //converstion here will probably FAIL so this makes this pointless.
            //here the compliter complains as the Type object has no Text Prop as it was not sepcified anywhere
            var theThingyouwant1 = xzy.Select(x => x.Text);
            //here you are OK as the complier can infer something
            var theThingyouwant2 = xzy.SelectOtherColumn(x => x.Text);
        }
    }
