    public static void Register(HttpConfiguration config)
        {
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("someConstraint", typeof(SomeConstraint ));
    
            config.MapHttpAttributeRoutes(constraintResolver);
        }
