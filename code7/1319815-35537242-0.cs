        HyperLink hp = new HyperLink();
        hp.Text = gr.Cells[0].Text;
        hp.NavigateUrl = "~/Default.aspx?name=" + hp.Text;
        gr.Cells[0].Controls.Add(hp);
    }`
