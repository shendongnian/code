    public class SystemTypes : IGenericValue<float> // Implement IGenericValue for other Types.
    {
        GenericBase<float> IGenericValue<float>.ConstructGenericBase()
        {
            throw new NotImplementedException();
        }
    }
