    if (comboBoxSubjectCodeRegister.SelectedIndex > -1)
    {
        OleDbCommand oda1 = new OleDbCommand("select subject_abbreviation from subjectinfo where subject_code = '" + comboBoxSubjectCodeRegister.SelectedValue + "'", con);
        textBoxSubjectAbbreviationRegister.Text = Convert.ToString(oda1.ExecuteScalar());
    }
    else
    {
        textBox1.Text = "";
    }
