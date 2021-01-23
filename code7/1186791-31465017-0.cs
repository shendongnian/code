    var paramS = Expression.Parameter(typeof(Entidade), "s");
    var paramT = Expression.Parameter(typeof(Detalhe), "t");
    var firstSelectMethod = typeof(Enumerable).GetMethods().First(m => m.Name == "Select").MakeGenericMethod(typeof(Entidade), typeof(Resultado));
    var secondSelectMethod = typeof(Enumerable).GetMethods().First(m => m.Name == "Select").MakeGenericMethod(typeof(Detalhe), typeof(DetalheResultado));
    var lista4 = Expression.Call(
        firstSelectMethod,
        Expression.Constant(source),
        Expression.Lambda(
            Expression.MemberInit(
                Expression.New(typeof(Resultado).GetConstructor(Type.EmptyTypes)), 
                Expression.Bind(
                    typeof(Resultado).GetProperty("Detalhes"), 
                    Expression.New(
                        typeof(List<DetalheResultado>).GetConstructor(new Type[] {typeof(IEnumerable<DetalheResultado>)}),
                        Expression.Call(
                            secondSelectMethod,
                            Expression.Property(
                                paramS,
                                "Detalhes"
                            ),
                            Expression.Lambda(
                                Expression.MemberInit(
                                    Expression.New(typeof(DetalheResultado).GetConstructor(Type.EmptyTypes)), 
                                    Expression.Bind(
                                        typeof(DetalheResultado).GetProperty("Id"),
                                        Expression.Property(paramT, "Id")
                                    ),
                                    Expression.Bind(
                                        typeof(DetalheResultado).GetProperty("Valor"),
                                        Expression.Property(paramT, "Valor")
                                    )
                                ),
                                paramT
                            )
                        )
                    )
                )
            ), 
            paramS
        )
    );
