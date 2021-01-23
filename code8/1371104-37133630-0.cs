    protected void Export_to_Excel_Click(object sender, EventArgs e)
    {
        bindgriddata();
        Grd_MidData.DataSource = objDS;  // Dataset
        Grd_MidData.DataBind();
        using (XLWorkbook wb = new XLWorkbook())
        {
            try
            {
                //creating worksheet
                var ws = wb.Worksheets.Add("Report");
                //adding columms header
                int columnscount = objDS.Tables[0].Columns.Count;
                char a = 'A';
                for (int j = 1; j <= columnscount; j++)
                {
                    string str = a + "1";
                    ws.Cell(str).Value = objDS.Tables[0].Columns[j - 1].ColumnName.ToString();
                    ws.Cell(str).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    a++;
                }
                ws.Columns().AdjustToContents();
                //formatting columns header 
                var rngheaders = ws.Range("A1:J1");
                rngheaders.FirstRow().Style
                    .Font.SetBold()
                    .Font.SetFontSize(12)
                    .Font.SetFontColor(XLColor.Black)
                    .Fill.SetBackgroundColor(XLColor.DeepSkyBlue)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Border.OutsideBorder = XLBorderStyleValues.Thin;
                ////adding data to excel
                int k = 2;
                foreach (DataRow row in objDS.Tables[0].Rows)
                {
                    char b = 'A';
                    string str = b + "" + k;
                    for (int i = 0; i < objDS.Tables[0].Columns.Count; i++)
                    {
                        ws.Cell(str).Value = row[i].ToString();
                        ws.Cell(str).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        ws.Cell(str).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                        b++;
                        str = b + "" + k;
                    }
                    k++;
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Customer.xlsx");
            }
            catch { }
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }
