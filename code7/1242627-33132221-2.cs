    var output = new StringBuilder();
    output.AppendLine("Image information for image " + WimFile);
    output.AppendLine("");
    output.AppendLine("");
    output.AppendLine(String.Format("Image index         : {0}" + System.Environment.NewLine, info.ImageIndex.ToString()));
    ...
    ...
    txtOutput.Text = output.ToString();
