    protected void CevapEkIndir_Click(object sender, EventArgs e)
    {
        Button CevapEkIndir = ((Button)sender);
        Control container = CevapEkIndir.NamingContainer;
        Label CevapEk = (Label)container.FindControl("CevapEk");
        if (CevapEk != null)
        {
            string dosya = CevapEk.Text;
            string dosya_path = @"\uploadCevap\";
            dosya_path = dosya_path + dosya;
            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + dosya);
            Response.TransmitFile(Server.MapPath(dosya_path));
            Response.End();
        }
    }
