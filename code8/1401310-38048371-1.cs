		private void SubjectBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SomeBox subjectBox = (SomeBox)sender;
			SomeBox aBox;
			SomeBox nBox;
			SomeBox cBox;
			SomeBox mBox;
			SomeBox maxBox;
			// The sender object is the actual subjectBox. Therefore, based on who sent the event
			// we use different nBox, cBox and maxBox.
			if (subjectBox == subjectBox1)
			{
				aBox = aBox1;
				nBox = nBox1;
				cBox = cBox1;
				mBox = mBox1;
				maxBox = maxBox1;
			}
			else if (subjectBox == subjectBox2)
			{
				// Todo: Implement other assignments
			}
			// Original code, using local variables
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
