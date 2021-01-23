    var keys = new[] { "LanguageId", "TextId" };
    
    var param = Expression.Parameter(typeof(TranslatedText));
    var properties = keys.Select(p => Expression.Property(param, p)).ToList();
    
    var keyTupleType = typeof(KeyTuple<,>).Assembly.GetType(string.Format("AnonymousTypeExpression.KeyTuple`{0}",keys.Count()));
    keyTupleType = keyTupleType.MakeGenericType(properties.Select(p => p.Type).ToArray());
    
    var bindings = properties.Select((p,i) => Expression.Bind(keyTupleType.GetProperty(string.Format("Item{0}",i + 1)),p)).ToArray();
    var body = Expression.MemberInit(Expression.New(keyTupleType), bindings);
    var result= Expression.Lambda<Func<TranslatedText, object>>(body, param);
