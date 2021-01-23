            DataSet ds = new DataSet();
            foreach (DataTable d in ds.Tables)
            {
                d.TableName = "TableName";
            }
            ds.WriteXml("filepath");
            //Or
            DataTable dt = new DataTable("TableName");
            dt.WriteXml("filepath");
