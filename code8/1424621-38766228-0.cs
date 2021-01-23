     using (var writer = new StreamWriter(filepath, true))
       	{
			{
            writer.Write(productTextBox.Text + Environment.NewLine);
			}
        writer.Close();
        }
