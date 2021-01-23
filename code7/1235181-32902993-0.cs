    var personP = Expression.Parameter(typeof(Person), "xy");            // Creates xy Parameter
    var SecQuestionsProp = Expression.Property(personP, "SecQuestions"); // Creates xy.SecQuestions
    
    var anyMethodInfo = typeof(Enumerable).GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
        .Where(m => m.Name == "Any" && m.IsGenericMethod) // Search for Any methods...
        .Select(m => new {
                            Method = m,
                            Params = m.GetParameters(),
                            Args = m.GetGenericArguments()
                         })
        .Where(x => x.Args.Length == 1 
            && x.Params.Length == 2 
            && x.Params[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(x.Args)
            && x.Params[1].ParameterType == typeof(Func<,>).MakeGenericType(new Type[] { x.Args.First(), typeof(bool) })) // Get the one defined as Any<TSource>(IEnumerable<TSource>, Func<TSource, bool>)
        .Select(x => x.Method)
        .First();
    
    var keyValuePairP = Expression.Parameter(typeof(KeyValuePair<string, string>), "x"); // Creates x Parameter
    var KeyProp = Expression.Property(keyValuePairP, "Key");                             // Creates x.Key
    var keyComparisonValue = Expression.Constant("PlaceOfBirth");                        // Creates the value that will be compared to x.Key
    var keyComparison = Expression.Equal(KeyProp, keyComparisonValue);                   // Creates the comparison (x.Key == "PlaceOfBirth")
    
    var ValueProp = Expression.Property(keyValuePairP, "Value");                         // Creates x.Value
    var valueComparisonValue = Expression.Constant("Madurai");                           // Creates the value that will be compared to x.Value
    var valueComparison = Expression.Equal(ValueProp, valueComparisonValue);             // Creates the comparison (x.Value == "Madurai")
    
    var anyPredicate = Expression.Lambda(Expression.AndAlso(keyComparison, valueComparison), new ParameterExpression[] { keyValuePairP }); // Creates x => x.Key == "PlaceOfBirth" && x.Value == "Madurai"
    
    var filterMeMethod = Expression.Lambda<Func<Person, bool>>
        (Expression.Call(anyMethodInfo.MakeGenericMethod(new Type[] { typeof(KeyValuePair<string, string>) })
                        , new Expression[] { SecQuestionsProp, anyPredicate })
         , personP);  //Creates xy => xy.SecQuestions.Any(x => x.Key == "PlaceOfBirth" && x.Value == "Madurai")
    
    var r1 = persons.FilterMe(filterMeMethod.Compile());  // Calls FilterMe with xy => xy.SecQuestions.Any(x => x.Key == "PlaceOfBirth" && x.Value == "Madurai") as parameter
