			private void button1_Click(object sender, EventArgs e)
			{
				talonary talonaryobj = new talonary(txtname.Text, txtlastname.Text,double.Parse(txtSalary.Text));
				lsttalonary.Items.Add(talonaryobj.Name);
				lsttalonary.Items.Add(talonaryobj.Lastname);
				//lsttalonary.Items.Add(talonaryobj.calculateSalary);   //ERROR LINE
				lsttalonary.Items.Add(string.Format("##some format string here##", talonaryobj.Salary));
			}
