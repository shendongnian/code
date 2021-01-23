    var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly;
    var pBuilder =
        circleAreaExpression.Target.GetType()
            .GetFields(flags)
            .Single(y => y.FieldType == typeof (PropertyBuilder))
            .GetValue(circleAreaExpression.Target);
