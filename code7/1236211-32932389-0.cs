    using (SqlConnection cn = new SqlConnection(...))
    {
          cn.Open();
          using (SqlBulkCopy copy = new SqlBulkCopy(cn))
          {
                copy.WriteToServer(dataTable);
          }
    }
