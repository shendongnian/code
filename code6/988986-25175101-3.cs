    public class CustomBodyModelValidator : DefaultBodyModelValidator
    {
        public override bool ShouldValidateType(Type type)
        {
            return type.Namespace != "NodaTime" && base.ShouldValidateType(type);
        }
    }
