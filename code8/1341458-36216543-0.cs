    /// <summary>
    /// Method to add a unique constraint to a property of an entity.
    /// The unique constraint name is usually "UI_{classname}_{propertyname}".
    /// </summary>
    /// <param name="prop">The property for which a unique constraint is added</param>
    /// <param name="constraintName">The name of the constraint</param>
    /// <param name="constraintOrder">
    ///     Optional constraint order for multi column constraints.
    ///     This can be used if <see cref="HasUniqueConstraint"/> is called for multiple properties to define the order of the columns.
    /// </param>
    public static void HasUniqueConstraint(this PrimitivePropertyConfiguration prop, string constraintName, int constraintOrder = 1) {
        prop.HasColumnAnnotation(IndexAnnotation.AnnotationName,
            new IndexAnnotation(new IndexAttribute(constraintName, constraintOrder) {
                IsUnique = true
            })
        );
    }
