    public class Test
    {
        [Fact]
        public void Foo()
        {
            const string text1 = "Text1";
            const string text2 = "Text2";
            var kernel = new StandardKernel();
            kernel.Bind<string>().ToConstant(text1);
            kernel.Get<string>().Should().Be(text1);
            kernel.Rebind<string>().ToConstant(text2);
            kernel.Get<string>().Should().Be(text2);
        }
    }
