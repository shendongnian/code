    public class DynamicCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Insert(
                0,
                new FilteringSpecimenBuilder(
                    new FixedBuilder(new AnythingObject()),
                    new ExactTypeSpecification(typeof(object))));
        }
    
        private class AnythingObject : DynamicObject
        {
            public override bool TryGetMember(
                GetMemberBinder binder,
                out object result)
            {
                result = new AnythingObject();
                return true;
            }
    
            public override bool TryInvokeMember(
                InvokeMemberBinder binder,
                object[] args,
                out object result)
            {
                result = new AnythingObject();
                return true;
            }
        }
    }
