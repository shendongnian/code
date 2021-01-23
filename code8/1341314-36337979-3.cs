    public class EnumUtilsTests
    {
        public enum MyEnum
        {
            [Description("Um")]
            One,
            [Description("Dois")]
            Two,
            [Description("Tres")]
            Three,
            NoDescription
        }
        public void Should_get_enum_description()
        {
            MyEnum.One.GetDescription().ShouldBe("Um");
            MyEnum.Two.GetDescription().ShouldBe("Dois");
            MyEnum.Three.GetDescription().ShouldBe("Tres");
            MyEnum.NoDescription.GetDescription().ShouldBe(null);
        }
        public void Should_get_all_enum_values_with_description()
        {
            var response = EnumUtils.GetItemsWithDescrition<MyEnum>();
            response.ShouldContain(x => x.Key == MyEnum.One && x.Value == "Um");
            response.ShouldContain(x => x.Key == MyEnum.Two && x.Value == "Dois");
            response.ShouldContain(x => x.Key == MyEnum.Three && x.Value == "Tres");
            response.ShouldContain(x => x.Key == MyEnum.NoDescription && x.Value == null);
        }
    }
