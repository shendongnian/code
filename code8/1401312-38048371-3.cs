		private void SubjectBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			SubjectBox_SelectedIndexChangedImpl((SomeBox)sender, aBox1, nBox1, cBox1, mBox1, maxBox1);
		}
		private void SubjectBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			SubjectBox_SelectedIndexChangedImpl((SomeBox)sender, aBox2, nBox2, cBox2, mBox2, maxBox2);
		}
		private void SubjectBox_SelectedIndexChangedImpl(SomeBox sender, SomeBox aBox, SomeBox nBox, SomeBox cBox, ......)
		{
			string[] igcseSubjects = new string[5] { "IGCSE Maths", "IGCSE English", "IGCSE Chem", "IGCSE Phys", "IGCSE Bio" };
			string selectedSubject = (string)subjectBox.SelectedItem;
			if (igcseSubjects.Contains(selectedSubject))
			{
				nBox.Visible = aBox.Visible = mBox.Visible = eBox.Visible = false;
				cBox.Visible = true;
				maxBox.Text = "100";
			}
			else
			{
				nBox.Visible = aBox.Visible = mBox.Visible = eBox.Visible = true;
				cBox.Visible = false;
				maxBox.Text = "20";
			}
		}
