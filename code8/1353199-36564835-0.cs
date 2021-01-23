        private void Find_Click(object sender, EventArgs e)
        {
            string ConStr = Convert.ToString(ConfigurationManager.AppSettings["strConn"]);
            SqlConnection vcon1 = new SqlConnection(ConStr);
            vcon1.Open();
            string querystring = "SELECT * FROM AssignedSolution WHERE CaseId = @caseid";
            SqlCommand Vcom = new SqlCommand(querystring, vcon1);
            Vcom.Parameters.AddWithValue("@caseid",Convert.ToInt32(txtCASEID.Text));
            
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(Vcom);
                da.Fill(dt);
                dataGridView1.DataSource = dt;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("error.occured" + ex.Message);
            }
            finally
            {
                Vcom.Dispose();
                vcon1.Close();
                vcon1.Dispose();
            }
        }
        // Use SqlDataReader
        private void button1_Click(object sender, EventArgs e)
        {
            string ConStr = Convert.ToString(ConfigurationManager.AppSettings["strConn"]);
            SqlConnection vcon1 = new SqlConnection(ConStr);
            vcon1.Open();
            string querystring = "SELECT * FROM AssignedSolution WHERE CaseId = @caseid";
            SqlCommand Vcom = new SqlCommand(querystring, vcon1);
            Vcom.Parameters.AddWithValue("@caseid", Convert.ToInt32(txtCASEID.Text));
            SqlDataReader dr = null;
            try
            {
                DataTable dt = new DataTable();
                dr = Vcom.ExecuteReader();              
                dt.Load(dr);  
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error.occured" + ex.Message);
            }
            finally
            {
                dr.Close();
                Vcom.Dispose();
                vcon1.Close();
                vcon1.Dispose();
            }
        } 
