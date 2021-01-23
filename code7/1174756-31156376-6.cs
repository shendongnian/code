    private void btnAddContent_Click(object sender, EventArgs e)
    {
        TContent content = new TContent(session);
        using (frmEditTContent form = new frmEditTContent(content, truck))
        {
            if (form.ShowDialog() == DialogResult.OK)
                truck.TContents.Add(content);
        }
    }
