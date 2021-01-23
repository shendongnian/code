    public static class TypeSyntaxFactory
    {
        /// <summary>
        /// Used to generate a type without generic arguments
        /// </summary>
        /// <param name="identifier">The name of the type to be generated</param>
        /// <returns>An instance of TypeSyntax from the Roslyn Model</returns>
        public static TypeSyntax GetTypeSyntax(string identifier)
        {
            return
                SyntaxFactory.IdentifierName(
                    SyntaxFactory.Identifier(identifier)
                );
        }
        /// <summary>
        /// Used to generate a type with generic arguments
        /// </summary>
        /// <param name="identifier">Name of the Generic Type</param>
        /// <param name="arguments">
        /// Types of the Generic Arguments, which must be basic identifiers
        /// </param>
        /// <returns>An instance of TypeSyntax from the Roslyn Model</returns>
        public static TypeSyntax GetTypeSyntax(string identifier, params string[] arguments)
        {
            return GetTypeSyntax(identifier, arguments.Select(GetTypeSyntax).ToArray());
        }
        /// <summary>
        /// Used to generate a type with generic arguments
        /// </summary>
        /// <param name="identifier">Name of the Generic Type</param>
        /// <param name="arguments">
        /// Types of the Generic Arguments, which themselves may be generic types
        /// </param>
        /// <returns>An instance of TypeSyntax from the Roslyn Model</returns>
        public static TypeSyntax GetTypeSyntax(string identifier, params TypeSyntax[] arguments)
        {
            return
                SyntaxFactory.GenericName(
                    SyntaxFactory.Identifier(identifier),
                    SyntaxFactory.TypeArgumentList(
                        SyntaxFactory.SeparatedList(
                            arguments.Select(
                                x =>
                                {
                                    if(x is GenericNameSyntax)
                                    {
                                        var gen_x = x as GenericNameSyntax;
                                        return
                                            GetTypeSyntax(
                                                gen_x.Identifier.ToString(),
                                                gen_x.TypeArgumentList.Arguments.ToArray()
                                            );
                                    }
                                    else
                                    {
                                        return x;
                                    }
                                }
                            )
                        )
                    )
                );
        }
    }
