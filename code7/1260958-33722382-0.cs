        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string strId = gridViewMain.SelectedRows[0].Cells["id"].Value.ToString();
            if (!string.IsNullOrEmpty(strId))
            {
            
                SqlCommand cmd = new SqlCommand(strQuery_GetAttachmentById, objConn);
                cmd.Parameters.AddWithValue("@attachId", strId);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
               
                DataTable dt = new DataTable();
              
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(da);
               
                da.Fill(dt);
               
                DataRow dr = dt.Rows[0];
                byte[] PDFBytes = (byte[])dr["attachment"];
                LoadPdf(PDFBytes);
            }
           
        }
        public void LoadPdf(byte[] pdfBytes)
        {
            var PDFstream = new MemoryStream(pdfBytes);
            LoadPdf(PDFstream);
        }
        public void LoadPdf(Stream pdfstream)
        {
            // Create PDF Document
            var pdfDocument = PdfDocument.Load(pdfstream);
            // Load PDF Document into WinForms Control
            pdfRenderer1.Load(pdfDocument);    
        }
    }
