    protectecd void ListBox1_SelectedIndexChanged(object sender,EventArgs e)
    {
          string fileName= ListBox1.SelectedItem.ToString();
          Response.ContentType = "Application/pdf";
        Response.AppendHeader("Content-Disposition",string.Format("attachment; filename={0}",filename));
        Response.TransmitFile(fileName);
        Response.End();
    }
