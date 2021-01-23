    var newPatient= new Patient();
    newPatient.Name = textBox1.Text;
    newPatient.Family = textBox2.Text;
    if
        ( 
            Ort.Grid.Count
            (
                x=>
                x.Name==newPatient.Name && 
                x.Family==newPatient.Family
            ) > 0
        )
            MessageBox.Show("This is an existing patient");
