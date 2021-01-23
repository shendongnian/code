                SaveFileDialog svg = new SaveFileDialog();
                svg.FileName = "Data Report - All Books";//set default file name
                svg.Filter = "Pdf Files|*.pdf";
                
                //This needs to be before dialog is shown.
                svg.OverwritePrompt = true;//tell user to overwrite
                if (svg.ShowDialog() == DialogResult.OK)
                {
                   
                    using (FileStream stream = new FileStream(svg.FileName + ".pdf", FileMode.Create))
                    {
    
                        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfDoc, stream);
    
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();
    
                    }
                    MetroMessageBox.Show(this, "Successfully save PDF report.", "SUCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
