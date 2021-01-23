        protected void Page_Init(object sender, EventArgs e)
        {
            DataTable dt = GetData();
            //int numberOfRecords = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                var PanelFormFields = new Panel();
                var LabelFormFields = new Label();
                var ListItemFormFields = new ListItem();
                LabelFormFields.Text = row[0].ToString();
                CheckBoxListFormFields.Items.Add(new ListItem(row[0].ToString(), "C"));
                PanelFormFields.Controls.Add(LabelFormFields);
                PanelFormFields.Controls.Add(CheckBoxListFormFields);
            }
        }
        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["Events2"].ConnectionString))
            {
                sqlConn2.Open();
                string sql = string.Format("SELECT DisplayName FROM FormField WHERE EventId = 1 AND Visible = 0 ORDER BY ColumnOrder ASC;");
                using (SqlCommand sqlCmd2 = new SqlCommand(sql, sqlConn2))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCmd2))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
