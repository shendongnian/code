     IEnumerable InvokeDataTableMap(DataTable dtb, Type elementType)
     {
           var definition = typeof(Utils).GetMethod("DataTableMapToList");
           var method = definition.MakeGenericMethod(elementType);
           (IEnumerable) return method.Invoke(null, new object[]{dtb});
     }
