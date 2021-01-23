    private void cbalumno_SelectedIndexChanged(object sender, EventArgs e)
    {
         DataRowView vrow = (DataRowView)cbalumno.SelectedItem;
         string sValue = vrow.Row["Name"].ToString();
    }
