    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Create a Dynamic Panel
        pnlTextBox = new Panel();
        pnlTextBox.ID = "pnlTextBox";
        pnlTextBox.BorderWidth = 1;
        pnlTextBox.Width = 300;
        this.form1.Controls.Add(pnlTextBox);
     
        //Create a LinkDynamic Button to Add TextBoxes
        LinkButton btnAddtxt = new LinkButton();
        btnAddtxt.ID = "btnAddTxt";
        btnAddtxt.Text = "Add TextBox";
        btnAddtxt.Click += new System.EventHandler(btnAdd_Click);
        this.form1.Controls.Add(btnAddtxt);
       
        //Recreate Controls
        RecreateControls("txtDynamic", "TextBox");
    }
