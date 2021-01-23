    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading;
    private Row[] CopyVolatileList(List<Row> original)
    {
        while (true)
        {
            // Get _items and _size values which are safe to use in tandem.
            int version = GetVersion(original); // _version.
            Row[] items = GetItems(original); // _items.
            int count = original.Count; // _size.
            if (items.Length < count)
            {
                // Definitely a torn read. Copy will fail.
                continue;
            }
            // Copy.
            Row[] copy = new Row[count];
            Array.Copy(items, 0, copy, 0, count);
            // Stabilization window.
            Thread.Sleep(1);
            // Validate.
            if (version == GetVersion(original)) {
                return copy;
            }
                
            // Keep trying.
        }
    }
    static Func<List<Row>, int> GetVersion = CompilePrivateFieldAccessor<List<Row>, int>("_version");
    static Func<List<Row>, Row[]> GetItems = CompilePrivateFieldAccessor<List<Row>, Row[]>("_items");
    static Func<TObject, TField> CompilePrivateFieldAccessor<TObject, TField>(string fieldName)
    {
        ParameterExpression param = Expression.Parameter(typeof(TObject), "o");
        MemberExpression fieldAccess = Expression.PropertyOrField(param, fieldName);
        return Expression
            .Lambda<Func<TObject, TField>>(fieldAccess, param)
            .Compile();
    }
