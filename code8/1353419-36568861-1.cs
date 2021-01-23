		private void btnSubmit_Click(object sender, EventArgs e) {
			PersonList newPerson = new Person(
			txtActive.Text,
			txtName.Text,
			txtFrom.Text,
			txtAge.Text,
			txtGender.Text,
			txtCountry.Text);
		if (newPerson.check())
			erase();
		}
