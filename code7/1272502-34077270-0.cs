    // Gather the Info
    string path = e.Row.Cells[1].Text;
    var pdfReader = new PdfReader(path);
    var CreatedDate = pdfReader.Info["CreationDate"];
    e.Row.Cells[13].Text = Convert.ToString(CreatedDate);
    string sCreatedDate = Convert.ToString(CreatedDate).Remove(0, 2)
    // Convert and Compare
    DateTime Created = Convert.ToDateTime(sCreatedDate);
    DateTime Compare = Convert.ToDateTime(e.Row.Cells[14].Text);
    if (Compare > Created)
    {
        e.Row.Cells[15].Text = "actualizar";
    }
