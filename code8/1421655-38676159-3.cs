    this.hide();
    List<string> results = new List<string>(); // List of all the returned results
    for (int i = 0; i < 5; i++)
        results.Add(form2.GetInput());
    this.Show();
    MessageBox.Show(string.Join("\n", results)); // Show all the results
    
