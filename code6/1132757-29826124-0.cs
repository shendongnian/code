    var notEmpty = new[]  { textBoxLectura1.Text, textBoxLectura2.Text, textBoxLectura3.Text}
    	.Where(s => !String.IsNullOrEmpty(s)
    	.ToArray();
    	
    if (!notEmpty.Any())
    {
    	MessageBox.Show("No Entries");
    	return;
    }
    
    Console.WriteLine(string.Join(Environment.NewLine, notEmpty));
