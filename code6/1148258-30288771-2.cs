    public void sp_insert(string pro_name, params ColValueWrap[] pro_vals)
    {
       foreach (var val in pro_vals)
       {
            Console.WriteLine(val.Col + ":" + val.Val);
       }
       `enter more code here`[...]
    }
    sp_insert("procedure_name",new ColValueWrap("@col1", "val1"), new ColValueWrap("@col2", "val2"));
