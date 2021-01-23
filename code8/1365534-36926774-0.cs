    cbFabricante.SuspendLayout();
    cbModelo.SuspendLayout();
    cbNumera.SuspendLayout();
    for (int i = 0; i < listar.Count; i++)
    {
        cbFabricante.Items.Add(listar[i].fabricante);
        cbModelo.Items.Add(listar[i].modelo);
        cbNumera.Items.Add(listar[i].numeracao);
    }
    cbFabricante.ResumeLayout();
    cbModelo.ResumeLayout();
    cbNumera.ResumeLayout();
