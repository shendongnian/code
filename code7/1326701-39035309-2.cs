    public class StringIfNotFormattableStringAdapterTest
    {
        public interface IStringOrFormattableStringOverload
        {
            void Overload(StringIfNotFormattableStringAdapter s);
            void Overload(FormattableString s);
        }
        private readonly IStringOrFormattableStringOverload _stringOrFormattableStringOverload =
            Substitute.For<IStringOrFormattableStringOverload>();
        public interface IStringOrFormattableStringNoOverload
        {
            void NoOverload(StringIfNotFormattableStringAdapter s);
        }
        private readonly IStringOrFormattableStringNoOverload _noOverload =
            Substitute.For<IStringOrFormattableStringNoOverload>();
        [Fact]
        public void A_Literal_String_Interpolation_Hits_FormattableString_Overload()
        {
            _stringOrFormattableStringOverload.Overload($"formattable string");
            _stringOrFormattableStringOverload.Received().Overload(Arg.Any<FormattableString>());
        }
        [Fact]
        public void A_String_Hits_StringIfNotFormattableStringAdapter_Overload()
        {
            _stringOrFormattableStringOverload.Overload("plain string");
            _stringOrFormattableStringOverload.Received().Overload(Arg.Any<StringIfNotFormattableStringAdapter>());
        }
        [Fact]
        public void An_Explicit_FormattableString_Detects_Missing_FormattableString_Overload()
        {
            Assert.Throws<InvalidOperationException>(
                () => _noOverload.NoOverload((FormattableString) $"this is not allowed"));
        }
    }
