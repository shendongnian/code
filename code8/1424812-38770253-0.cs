    protected void Page_Init(object sender, EventArgs e)
    {
        var btnEdit = new Button {ID = "btnEdit", Text = "Edit" };
        btnEdit.Click += btnEdit_OnClick;
        PlaceHolder1.Controls.Add(btnEdit);
    }
