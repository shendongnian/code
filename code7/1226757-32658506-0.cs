    public void AdicionaConta(Conta novaConta)
    {
        comboContas.Items.Add(novaConta);
        comboContas.DisplayMember = "Titular.DisplayName";
    }
