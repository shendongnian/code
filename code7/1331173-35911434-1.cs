    private int i = 0;
            private void cmbDistaccamento_SelectedIndexChanged(object sender, EventArgs e)
            {
    
                try
                {
                    i += 1;
                    MessageBox.Show("print iteration i : " +i.ToString());
    
                    _cmbDistaccamentoResult = Int32.Parse(cmbDistaccamento.SelectedValue.ToString());
                    MessageBox.Show(_cmbDistaccamentoResult.ToString());
                    //Convert.ToInt32((cmbDistaccamento.SelectedValue.ToString()));
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Impossibile convertire il valore(value) combobox da string a int \r\n" + ex.Message);
                }
            }
