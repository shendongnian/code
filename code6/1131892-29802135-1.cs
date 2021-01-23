        public static void Test()
        {
            //Group controls by a group identifier in this case the string 'name'`
            TextBox txtForename = new TextBox();
            TextBox txtSurname = new TextBox();
            TextBox txtNotAName = new TextBox();
            GroupBox groupBox = new GroupBox();
            groupBox.Controls.Add(txtSurname);
            
            txtForename.Name = "name";
            txtSurname.Name = "name";
            txtNotAName.Name = "notAName";
            Form form1 = new Form();
            form1.Controls.Add(txtForename);
            form1.Controls.Add(txtNotAName);
            form1.Controls.Add(groupBox);
            DisplayControlsByName(form1, "name");
            Console.ReadLine();
        }
        private static void DisplayControlsByName(Control searchControl, string name)
        {
            foreach (Control control in searchControl.Controls)
            {
                if (control.Name == name)
                {
                    Console.WriteLine("true");
                }
                if (control.Controls.Count > 0)
                {
                    DisplayControlsByName(control, name);
                }
            }
        }
