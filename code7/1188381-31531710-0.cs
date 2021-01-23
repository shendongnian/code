    for (int element = 0; element < testList.Count;element++ )
                {
                    string name = testList.ElementAt(element).ToString();
                    PdfPCell cell1 = new PdfPCell(new Phrase(name));
                    cell1.BackgroundColor = new iTextSharp.text.Color(160, 160, 210);
                    cell1.Colspan = 11;
                    cell1.HorizontalAlignment = 1;
                    pdfTable.AddCell(cell1);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                if(dataGridView1.Rows[i].Cells[6].Value.ToString() == name.ToString())
                                { 
                                    if (j == 6 || j == 10)
                                    {
                                        pdfTable.AddCell("*****");
                                    }
                                    else if (j == 0)
                                    {
                                        pdfTable.AddCell(dataGridView1.Rows[i].Cells[6].Value.ToString());
                                    }
                                    else if (j == 6)
                                    {
                                        pdfTable.AddCell(dataGridView1.Rows[i].Cells[0].Value.ToString());
                                    }
                                    else
                                    {
                                        pdfTable.AddCell(dataGridView1.Rows[i].Cells[j - 1].Value.ToString());
                                    }
                                }                                
                            }
                            else
                            {
                                pdfTable.AddCell(" ");
                            }
                        }
                    }
                } 
