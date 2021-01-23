    private void ReCalculate()
    {
    Worksheet worksheet;
    worksheet = _spreadsheet.Workbook.Worksheets[0];
    worksheet.Cell("A2").Value = System.Convert.ToInt32(TextBox1.Text);
    worksheet.Cell("B2").Value = System.Convert.ToInt32(TextBox2.Text);
    worksheet.Cell("C2").Formula = TextBox3.Text;
    worksheet.Cell("C2").Calculate();
    TextBox4.Text = worksheet.Cell("C2").Value.ToString();
    }
