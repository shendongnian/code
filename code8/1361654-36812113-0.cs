    using System;
    using System.Data;
     public int Maths(string operation)
            {
                object result=new DataTable().Compute(operation, null);
                return Int32.Parse(result.ToString());
            }
