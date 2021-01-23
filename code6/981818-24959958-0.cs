    var bindings = fields.Split(',').Select(o => o.Trim())
                .Select(o =>
                {
                    // property "Field1"
                    var mi = typeof(TA).GetProperty(o);
                    // original value "o.Field1"
                    var xOriginal = Expression.Property(xParameter, mi);
                    // set value "Field1 = o.Field1"
                    return (MemberBinding)Expression.Bind(mi, xOriginal);
                }
            );
