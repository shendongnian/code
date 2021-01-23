    this.hide();
    List<string> results = new List<string>(); // List of all the returned results
    for (int i = 0; i < 5; i++)
    {
        form2 obj_form2 = new form2();
        obj_form2.ShowDialog();
        results.Add(obj_form2.textBox.Text);
    }
    this.Show();
    MessageBox.Show(string.Join("\n", results)); // Show all the results
