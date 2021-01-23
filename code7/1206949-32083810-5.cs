    public ViewResultBase Editar(int id)
    {
        Modelo model = this.Service.GetForEdit(this.IdEmpresa, id);
        return base.SwitchView(model);
    }
