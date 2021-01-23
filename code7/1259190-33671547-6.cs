    public class ChildClass : BaseClass<ChildClassExists>
    {
        protected override bool InternalExistsCheck<T>(ChildClassExists exists, out T existingElement)
        {
            ....
        }
    }
