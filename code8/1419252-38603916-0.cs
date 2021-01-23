    StringBuilder contentBuilder = new StringBuilder();
    foreach (TextBox dynamicText in this.Controls.OfType<TextBox>())
    {
        contentBuilder.AppendFormat("Text in {0} is {1} \n", dynamicText.Name, dynamicText.Text);
    }
    string pathOfFile = @"path here";
    System.IO.File.WriteAllText(pathOfFile,contentBuilder.ToString());
