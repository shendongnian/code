    if (signature.Name == "Min" || signature.Name == "Max")
            {
                typeArgs = new Type[] { elementType, args[0].Type };
            }
            else if (signature.Name == "Select")
            {
                typeArgs = new Type[] { elementType, Expression.Lambda(args[0], innerIt).Body.Type };
            } 
