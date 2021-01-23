    private async void Btnestado_Click(object sender, EventArgs e)
    {
        this.TxtEstado.Text = "Entrando..";
        Vdispositivo = "Alarma";
        
        BasicHttpBinding binding = CreateBasicHttp();
        var svc = new Service1Client(binding, Endpoint);
        
        var task = Task.Factory.FromAsync<string, bool>(
            svc.BeginConsStatus,
            svc.EndConsStatus,
            "Alarma", null);
        
        var result = await task;
        
        if (result == true && Vdispositivo == "Alarma") {
            this.Btnestado.Text = "On";
            Vpool = true;
        } else {
            this.Btnestado.Text = "Off";
            Vpool = false;
        }
        
        if (result == true && Vdispositivo == "Sala1") {
            this.BtnSala1.Text = "On";
            Vpool = true;
        } else {
            this.BtnSala1.Text = "Off";
            Vpool = false;
        }
    }
