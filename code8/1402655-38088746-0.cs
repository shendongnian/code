    private void Execute_Click(object sender, EventArgs e)
    {
      Task.Factory.StartNew(() =>
      {
        if (InvokeRequired)
        {
          Invoke(new MethodInvoker(DoSomething));
        }
        else
        {
          DoSomething();
        }
      });
    }
    
    private void DoSomething()
    {
      try
      {
        //Execution Pane
        timer1.Start();
        progressBar1.Maximum = checkedListBox1.CheckedItems.Count;
    
        richTextBox2.Text = "";
        var file_name = "\\test1.sql";
        file_name = textBox1.Text + file_name;
        {
          string line;
          line = null;
    
          foreach (var item in checkedListBox1.CheckedItems)
          {
            var sql_name = "\\test1.sql";
            sql_name = textBox1.Text + sql_name;
            var SaveFile = new StreamWriter(sql_name);
            SaveFile.WriteLine(":r \"" + textBox1.Text + "\\" + item + "\"");
            SaveFile.Close();
    
            line += item + "\n";
    
            var sql = new StreamReader(sql_name);
            //richTextBox1.Text = sr.ReadToEnd();
            sql.Close();
            sql.Dispose();
    
            //Create a batchfile for execution of consolidated script 
            var execute = "\\Script_Runner.bat";
            execute = textBox1.Text + execute;
            var SaveFile2 = new StreamWriter(execute);
            SaveFile2.WriteLine("sqlcmd -S localhost -E -i " + textBox1.Text + "\\" + "test1.sql");
            //Environment.NewLine + "pause");
            SaveFile2.Close();
    
            //running the batchfile
            var ScriptRun = "\\Script_Runner.bat";
            ScriptRun = textBox1.Text + ScriptRun;
            Process.Start(ScriptRun);
    
            progressBar1.PerformStep();
            Refresh();
          }
    
          richTextBox2.Text = line;
          richTextBox2.Text += "\nData Patch Completed.";
    
          var transfer = label3.Text;
          //NotificationForm NF = new NotificationForm();
          //NF.Show();
        }
      }
      catch (Exception ex)
      {
        var filePath = @"C:\Error.txt";
        filePath = textBox1.Text + filePath;
    
        using (var writer = new StreamWriter(filePath, false))
        {
          writer.WriteLine("Message :" + ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                            "" + Environment.NewLine + "Date :" + DateTime.Now);
          writer.WriteLine(Environment.NewLine +
                            "-----------------------------------------------------------------------------" +
                            Environment.NewLine);
        }
      }
    }
