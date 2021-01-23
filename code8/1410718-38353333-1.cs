    HttpWebResponse webResponse = getDocumentRequest.ToWebResponse();
    Stream stream = webResponse.GetResponseStream();
    Encoding enc = System.Text.Encoding.GetEncoding(UTF8);
    StreamReader loResponseStream = new StreamReader(webResponse.GetResponseStream(), enc);
    string serverResponse = loResponseStream.ReadToEnd();
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.FileName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
        System.IO.File.WriteAllText(saveFileDialog.FileName, serverResponse, Encoding.Default);
    }
