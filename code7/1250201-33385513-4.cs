    public class DbContextModule : Module
    {
        protected override void AttachToComponentRegistration(
            IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += Registration_Preparing;
        }
        private void Registration_Preparing(Object sender, PreparingEventArgs e)
        {
            Parameter parameter = new ResolvedParameter(
                                    (pi, c) => pi.ParameterType == typeof(DbContext),
                                    (pi, c) =>
                                    {
                                        if (pi.Name.Equals("dbContextA", StringComparison.OrdinalIgnoreCase))
                                        {
                                            return c.ResolveNamed<DbContext>("databaseA");
                                        }
                                        else if (pi.Name.Equals("dbContextB", StringComparison.OrdinalIgnoreCase))
                                        {
                                            return c.ResolveNamed<DbContext>("databaseB");
                                        }
                                        else
                                        {
                                            throw new NotSupportedException($"DbContext not found for '{pi.Name}' parameter name");
                                        }
                                    });
            e.Parameters = e.Parameters.Concat(new Parameter[] { parameter });
        }
    }
