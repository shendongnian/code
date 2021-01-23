    string filePath = "path to text file";
    StringBuilder contentBuilder = new StringBuilder();
    foreach (Control item in Controls)
    {
         //i don't remember if this check would work. if it doesn't work try item.GetType() == typeof(TextBox)
         if (item is TextBox)
         {
              contentBuilder.Append(((TextBox)item).Text);
         }
    }
    string content = contentBuilder.ToString();
    if(!string.IsEmptyOrWhiteSpace(content))
    {
        using(StreamWriter writer = new StreamWriter(filePath))
        {
            //check if Write or WriteLine or something else would work.
            writer.Write(content);
        }
    }
