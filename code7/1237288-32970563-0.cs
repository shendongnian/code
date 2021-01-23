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
