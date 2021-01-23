    Paciente patient = pacientes.FirstOrDefault(x => x.id == Convert.ToInt32(txtIDP.Text));
    if (patient == null)
    {
        txtNome.Clear();
        txtIdade.Clear();
        txtMorada.Clear();
        txtNumero.Clear();
        txtEmail.Clear();
        MessageBox.Show("Não existe nenhum paciente com esse ID!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);                
    }
    else
    {
        txtNomeP.Text = patient.nome;
        txtIdadeP.Text = Convert.ToString(patient.idade);
        txtMoradaP.Text = patient.morada;
        txtContatoP.Text = patient.contato;
        txtEmailP.Text = patient.email;                
    }
