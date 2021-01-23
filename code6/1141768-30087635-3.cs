        Form2 form2 = new Form2();
        if(form2.Show() ==  System.Windows.Forms.DialogResult.OK)
        {
            MyApp.Properties.Settings.Default.ContinuesLabelPrinter = form2.listBox1.SelectedItem.ToString();
        }
        
        form2.Dispose();  // <-- this might not be necessary
