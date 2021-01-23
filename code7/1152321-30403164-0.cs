    void Main()
    {
       DataTable one = new DataTable();
       one.Columns.Add("ID");
       one.Columns.Add("PCT");
       one.Rows.Add("1", "0.1");
       one.Rows.Add("2", "0.2");
       one.Rows.Add("3", "0.3");
       DataTable two = new DataTable();
       two.Columns.Add("ID");
       two.Columns.Add("PCT");
       two.Columns.Add("OldPCT");
       two.Rows.Add("1", "0.1", "0");
       two.Rows.Add("2", "0.1", "0");
       two.Rows.Add("3", "0.9", "0");
       two.Columns.Remove("OldP
       
       DataTable three = two.AsEnumerable().Except(one.AsEnumerable(),new RowEqualityComparer()).CopyToDataTable();
       foreach (DataRow dr in three.AsEnumerable())
       {
           string strID = dr[0].ToString();
           string strPCT = dr[1].ToString();
       }
    }
    
    
    class RowEqualityComparer : IEqualityComparer<DataRow>
    {
       public bool Equals(DataRow b1, DataRow b2)
       {
         if ((b1.Field<string>("ID") == b2.Field<string>("ID")) && (b1.Field<string>("PCT") == b2.Field<string>("PCT")))
         {
           return true;
         }
         else
         {
           return false;
         }
       }
    
       public int GetHashCode(DataRow bx)
       {
         return (bx.Field<string>("ID")+bx.Field<string>("PCT")).GetHashCode();
       }
    }
