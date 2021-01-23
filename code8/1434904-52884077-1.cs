    public class EnumerableNullEmptyEquivalenceRule : IAssertionRule
    {
        public bool AssertEquality(IEquivalencyValidationContext context)
        {
            // not applicable - return false
            if (!typeof(IEnumerable).IsAssignableFrom(context.SelectedMemberInfo.MemberType)) return false;
            return context.Expectation == null && ((IEnumerable)context.Subject).IsNullOrEmpty();
        }
    }
