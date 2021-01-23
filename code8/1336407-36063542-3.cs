    var memberRecord = new ClubMember()
    {// Tab ID
        Name = txtName.Text,
        Surname = txtSurname.Text,
        PassportNumber = (Int32)txtPasspt.text,
        MaritalStatus = cboMarital.SelectedValue == null ? null : cboMarital.SelectedValue.ToString(),
        Gender = cboGender.SelectedValue == null ? null : cboGender.SelectedValue.ToString(),
        DOB = dtpDob.Value,
        DataEntrada = dtpDataEntra.Value,
        Photo = ConvertImgToBinary(picBoxPhoto.Image),
        Country = cboCountry.SelectedValue == null ? null : cboCountry.SelectedValue.ToString(),
    };
