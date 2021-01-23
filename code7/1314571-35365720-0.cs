        //Input file
        //0001name      12345678
    internal class DecimalConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            decimal value = Convert.ToDecimal(from);
            valor = value / 100;
            return valor;
        }
        public override string FieldToString(object from)
        {
            decimal ret = (decimal)from;
            return Math.Round(ret - 100).ToString();
        }
    }
    public class MyClass
    {
        private void Read()
        {
            FixedLengthClassBuilder classBuilder = new FixedLengthClassBuilder("PessoaFixo");
            classBuilder.AddField("id", 4, typeof(int));
            classBuilder.AddField("name", 10, typeof(string));
            classBuilder.AddField("value", 8, typeof(decimal));
            classBuilder.LastField.Converter.TypeName = typeof(DecimalConverter).ToString();
            FileHelperEngine fhe = new FileHelperEngine(classBuilder.CreateRecordClass());
            var reg = fhe.ReadFile(@"C:\File.txt");
        }
    }
