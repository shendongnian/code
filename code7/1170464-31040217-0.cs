    public class MyModelMapper : ConventionModelMapper
    {
        public MyModelMapper()
        {
            this.IsEntity((type, isDeclared) =>
            {
                return type.Namespace.StartsWith("Models");
            });
        }
    }
