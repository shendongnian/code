    dc.UserDataClassesDataContext dc = new UserDataClassesDataContext();
    dc.AddNewUser(Convert.ToInt32(tbId.Text),
              tbFirstName.Text,
              tbMiddleName.Text,
              tbLastName.Text,
              tbMail.Text,
              tbUserName.Text,
              tbPassword.Text);
    dc.SaveChanges(); // Replace dc.SubmitChanges();
