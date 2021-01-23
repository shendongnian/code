    protected void AddTextBox(object sender, EventArgs e)
    {
        int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + 1;
        this.CreateTextBox("txtDynamic" + index);
    }
     
    private void CreateTextBox(string id)
    {
        TextBox txt = new TextBox();
        txt.ID = id;
        pnlTextBoxes.Controls.Add(txt);
     
        Literal lt = new Literal();
        lt.Text = "<br />";
        pnlTextBoxes.Controls.Add(lt);
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
        int i = 1;
        foreach (string key in keys)
        {
            this.CreateTextBox("txtDynamic" + i);
            i++;
        }
    }
