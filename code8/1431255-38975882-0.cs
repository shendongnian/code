        private void button1_Click(object sender, EventArgs e)
        {
            // Create the ElementHost control for hosting the
            // WPF UserControl.
            ElementHost host = new ElementHost();
            host.Dock = DockStyle.Fill;
            // Create the WPF UserControl.
            UserControl1 userControl1 = new UserControl1();
            userControl1.setText();
            // Assign the WPF UserControl to the ElementHost control's
            // Child property.
            host.Child = userControl1;
            // Add the ElementHost control to the form's
            // collection of child controls.
            this.Controls.Add(host);
        }
