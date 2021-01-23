    private void button3_Click(object sender, EventArgs e)
    {
        cita = new citacao(this);
        richEditControl1.Document.AppendText(citacao.valor_edit); // this line is the problem!
    }
