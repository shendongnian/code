    protected void Page_Init(object sender, EventArgs e)
    {
         ImageButton _btnRemoveEmpleado = new ImageButton();
        _btnRemoveEmpleado.ID = "btnOffice_1";
        _btnRemoveEmpleado.CommandArgument = Guid.NewGuid().ToString();
        _btnRemoveEmpleado.Height = 15;
        _btnRemoveEmpleado.Width = 15;
        _btnRemoveEmpleado.ImageUrl = "cross-icon.png";
        _btnRemoveEmpleado.Click += new ImageClickEventHandler(_btnRemoveEmpleado_Click);
        this.phPartesPersonal.Controls.Add(_btnRemoveEmpleado);
    }
