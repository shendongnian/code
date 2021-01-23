        static TResult SafeGet<TItem, TResult>(List<TItem> list, int index)
        {
            var typeArgumentsAreValid =
                // Either both are reference types and the same type 
                (!typeof (TItem).IsValueType && typeof (TItem) == typeof (TResult))
                // or one is a value type, the other is a generic type, in which case it must be
                || (typeof (TItem).IsValueType && typeof (TResult).IsGenericType
                    // from the Nullable generic type definition
                    && typeof (TResult).GetGenericTypeDefinition() == typeof (Nullable<>)
                    // with the desired type argument.
                    && typeof (TResult).GetGenericArguments()[0] == typeof(TItem)); 
            if (!typeArgumentsAreValid)
            {
                throw new InvalidOperationException();
            }
            var argumentsAreInvalid = list == null || index < 0 || index >= list.Count;
            if (typeof (TItem).IsValueType)
            {
                var nullableType = typeof (Nullable<>).MakeGenericType(typeof (TItem));
                if (argumentsAreInvalid)
                {
                    return (TResult) Activator.CreateInstance(nullableType);
                }
                else
                {
                    return (TResult) Activator.CreateInstance(nullableType, list[index]);
                }
            }
            else
            {
                if (argumentsAreInvalid)
                {
                    return default(TResult);
                }
                else
                {
                    return (TResult)(object) list[index];
                }
            }
        }
