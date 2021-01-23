public static bool Evaluate&lt;TField&gt;(this object entity, string fieldName, Predicate&lt;TField&gt; condition)
{
    Type entityType = entity.GetType();
    PropertyInfo propertyInfo = entityType.GetProperty(field);
    if (propertyInfo == null)
        throw new ArgumentException(string.Format("{0} doesn't exist on {1}", field, entityType.Name));
    var value = (TField)propertyInfo.GetValue(entity); //read the value and cast it to designated type, will raise invalid cast exception, if wrong
    return condition.Invoke(value); //invoke the predicate to check the condition
}
