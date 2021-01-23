    string wordToFind = "melp";
    int index = richTextBox1.Text.IndexOf( wordToFind );
    while( index != -1 )
    {
        richTextBox1.Select( index, wordToFind.Length );
        richTextBox1.SelectionColor = Color.Red;
        index = richTextBox1.Text.IndexOf( wordToFind, index + wordToFind.Length );
    }
