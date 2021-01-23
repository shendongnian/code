    StringBuilder arguments = new StringBuilder();
    arguments.Append(textBox5.Text);
    arguments.Append(textBox4.Text);
    arguments.Append(textBox6.Text);
    arguments.Append(textBox7.Text);
    arguments.Append(textBox8.Text);
    arguments.Append(textBox9.Text);
    System.Diagnostics.Process.Start("perl", arguments.ToString());
