    public class TestClass
    {
        public static void Test()
        {
            var expression = new BinaryExpression(
                new BinaryExpression(new BooleanExpression(false), new BooleanExpression(true), Operator.And), 
                new BinaryExpression(new BooleanExpression(true), new BooleanExpression(false), Operator.Or), 
                Operator.Or);
            Debug.WriteLine("Initial expression: ");
            Debug.WriteLine(expression); // "((False And True) Or (True Or False))"
            if (expression.ToString() != "((False And True) Or (True Or False))")
                throw new InvalidOperationException();
            var binary = BinaryFormatterHelper.ToBinary(expression);
            var expression2 = BinaryFormatterHelper.FromBinary<BinaryExpression>(binary);
            Debug.WriteLine("Deserialized expression: ");
            Debug.WriteLine(expression2);
            if (expression.ToString() != expression2.ToString())
            {
                throw new InvalidOperationException();
            }
            else
            {
                Debug.WriteLine("Deserialized and original expressions are identical");
            }
        }
    }
    public static partial class BinaryFormatterHelper
    {
        public static byte[] ToBinary<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, obj);
                return stream.ToArray();
            }
        }
        public static T FromBinary<T>(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                var formatter = new BinaryFormatter();
                var obj = formatter.Deserialize(stream);
                if (obj is T)
                    return (T)obj;
                return default(T);
            }
        }
    }
