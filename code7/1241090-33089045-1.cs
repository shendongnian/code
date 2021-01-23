    string numOftextbox= TextBox1.Text.ToString();
        int count = int.Parse(numOftextbox.Trim());
        List<TextBox> txts = new List<TextBox>();
        for (int j = 1; j <= count; j++)
        {
            string id = j.ToString();
            TextBox txtfname = new TextBox();
            txtfname.ID = "TextBox_" + id + "_";
            txtfname.Width = 160;
            txtfname.EnableViewState = true;
            txts.Add(txtfname);
            form1.Controls.Add(txtfname);
            form1.Controls.Add(new LiteralControl("<br/>"));
        }
        Session["myTextBoxes"] = txts;
