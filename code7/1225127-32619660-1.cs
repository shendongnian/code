    public class ValueTypeJsonWriter : JsonTextWriter
    {
        public ValueTypeJsonWriter(TextWriter textWriter)
            : base(textWriter)
        {
        }
        private void WriteValueType(object value)
        {
            if (value == null)
                base.WriteNull();
            else
            {
                var token = JToken.FromObject(value);
                base.WriteValue(token.Type.ToString());
            }
        }
        public override void WriteValue(object value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(bool value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(bool? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(byte value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(byte? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(byte[] value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(char value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(char? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(DateTime value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(DateTime? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(DateTimeOffset value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(DateTimeOffset? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(decimal value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(decimal? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(double value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(double? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(float value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(float? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(Guid value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(Guid? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(int value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(int? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(long value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(long? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(sbyte value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(sbyte? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(short value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(short? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(string value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(TimeSpan value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(TimeSpan? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(uint value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(uint? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(ulong value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(ulong? value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(Uri value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(ushort value)
        {
            WriteValueType(value);
        }
        public override void WriteValue(ushort? value)
        {
            WriteValueType(value);
        }
    }
