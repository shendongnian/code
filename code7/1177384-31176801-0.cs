    protected void ddMedType_SelectedIndexChanged(object sender, EventArgs e)
            {
                string MedType = ddMedType.SelectedItem.Text;
                string str = "select MedicineName,MedicineId from MedicineMaster where MedicineType = '" + MedType + "'";
                cmd = new SqlCommand(str, con);
                SqlDataReader reader = cmd.ExecuteReader();
                ddMedName.DataSource = reader;
                ddMedName.DataTextField = "MedicineName";
                ddMedName.DataValueField = "MedicineId";
                ddMedName.DataBind();
            }
