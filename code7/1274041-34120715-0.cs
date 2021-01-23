	var found = false;
	foreach (Paciente patient in pacientes)
	{
		if (patient.id == Convert.ToInt32(txtIDP.Text))
		{
			txtNomeP.Text = patient.nome;
			txtIdadeP.Text = Convert.ToString(patient.idade);
			txtMoradaP.Text = patient.morada;
			txtContatoP.Text = patient.contato;
			txtEmailP.Text = patient.email;
			found = true;
			break;
		}
	}
	if (!found)
	{
		txtNome.Clear();
		txtIdade.Clear();
		txtMorada.Clear();
		txtNumero.Clear();
		txtEmail.Clear();
		MessageBox.Show("Não existe nenhum paciente com esse ID!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
