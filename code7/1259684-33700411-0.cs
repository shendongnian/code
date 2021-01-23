    public class Customization : ICustomization
    {
        readonly Class item;
        public Customization() : this(new Class()) { }
        public Customization(Class item)
        {
            this.item = item;
        }
        public void Customize(IFixture fixture)
        {
            fixture.Inject(item);
            fixture.Inject<IInterface>(item);
        }
    }
