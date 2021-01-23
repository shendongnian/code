     private byte[] GetData(int id)
        {
            byte[] data = (from a in sd.UDocuments
                where a.DocID == id
                select a.DocData).First().ToArray();
           return data;
        }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int docid = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
            string name = GridView1.SelectedRow.Cells[2].Text;
            string contentType = GridView1.SelectedRow.Cells[3].Text;
            Response.Clear();
            Response.ContentType = contentType; //"application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + name);
            Response.BinaryWrite(GetData(docid));
            Response.End();
        }
