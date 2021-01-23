    private void btnAceptar_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvActivProfe.Items)
            {
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    SqlConnection con = new SqlConnection("data source = USUARIO-PC; initial catalog = BaseDeDatosGimnasio; integrated security=True ");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into [Actividades/Profesor](NumeroDocumentoProfesor,TipoDocumentoProfesor,CodigoActividad,Dia,HoraDesde,HoraHasta) values ('" + numeroDocProfe + "','" + tipoDocProfe + "','" + item.SubItems[i].Text + "','" + lblLunes + "','" + Convert.ToDateTime(comboBoxHDLunes.Text) + "','" + Convert.ToDateTime(comboBoxHHLunes.Text) + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
