    public DataTable Display(string fname)
            {
                try
                {
                    DataTable dt = obj.Display(fname);//call to DAL
                    DataView dv = new DataView(dt);
                    dv.RowFilter = string.Format("emp_f_name LIKE '%{0}%'",
                    textBox1.Text);
                    return dv.ToTable();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
