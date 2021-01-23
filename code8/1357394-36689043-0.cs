    DataAccess DA = new DataAccess();
    DataSet S = DA.CashData();
    DataTable Cash = S.Tables[0];
    DataTable Other = S.Tables[1];
    DataTable Check = S.Tables[2];
    DataTable Else = S.Tables[3];
    string s = "";
    foreach (DataRow row in Cash.Rows)
    {
        for (int i = 0; i < row.Columns.Count; i++)
        {
            s += row[0].ToString() + ";";
        }
        Console.ReadLine();
    }
    string[] data = s.Split(';');
    cell32.AddElement(new Paragraph(""));
    cell32.AddElement(new Paragraph(data[0]));
    cell32.AddElement(new Paragraph(data[1]));
