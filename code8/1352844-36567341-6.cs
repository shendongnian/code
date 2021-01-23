    public class DynamicCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Insert(
                0,
                new FilteringSpecimenBuilder(
                    new FixedBuilder(new AnythingObject(fixture)),
                    new ExactTypeSpecification(typeof(object))));
        }
    
        private class AnythingObject : DynamicObject
        {
            private readonly SpecimenContext context;
    
            public AnythingObject(ISpecimenBuilder builder)
            {
                context = new SpecimenContext(builder);
            }
    
            public override bool TryGetMember(
                GetMemberBinder binder,
                out object result)
            {
                if (binder.Name == "Bar")
                {
                    result = context.Resolve(typeof(string));
                }
                else
                {
                    result = new AnythingObject(context.Builder);
                }
    
                return true;
            }
    
            public override bool TryInvokeMember(
                InvokeMemberBinder binder,
                object[] args,
                out object result)
            {
                result = new AnythingObject(context.Builder);
                return true;
            }
        }
    }
