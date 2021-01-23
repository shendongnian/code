            //Group controls by a group identifier in this case the string 'name'`
            TextBox txtForename = new TextBox();
            TextBox txtSurname = new TextBox();
            TextBox txtNotAName = new TextBox();
            
            txtForename.Name = "name";
            txtSurname.Name = "name";
            txtNotAName.Name = "notAName";
            Form form1 = new Form();
            form1.Controls.Add(txtForename);
            form1.Controls.Add(txtSurname);
            form1.Controls.Add(txtNotAName);
            foreach (Control control in form1.Controls)
            {
                if (control.Name == "name")
                {
                    Console.WriteLine("true");
                }
            }
            Console.ReadLine();
