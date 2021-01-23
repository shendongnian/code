            DataTable dt = GetAccCode(c);
            DataView dv = new DataView(dt);
            string txt = e.Text;
            dv.RowFilter = string.Format("AccountDescription LIKE '%{0}%'", txt);       
            int a = dv.Count;
            if (dv.Count > 0)
            {
                dt = dv.ToTable();
            }
