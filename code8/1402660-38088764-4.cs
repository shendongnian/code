      private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
            //You need to add CheckForIllegalCrossThreadCalls to allow
            BackgroundWorker access the objects you used in the form.
            Label.CheckForIllegalCrossThreadCalls = false;
            ProgressBar.CheckForIllegalCrossThreadCalls = false;
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
            TextBox.CheckForIllegalCrossThreadCalls = false;
            try
        {                
            //Execution Pane
            timer1.Start();
            progressBar1.Maximum = checkedListBox1.CheckedItems.Count;
            richTextBox2.Text = "";
            string file_name = "\\test1.sql";
            file_name = textBox1.Text + file_name;
            {                 
                string line;
                line = null;
                foreach (Object item in checkedListBox1.CheckedItems)
                {
                    string sql_name = "\\test1.sql";
                    sql_name = textBox1.Text + sql_name;
                    StreamWriter SaveFile = new StreamWriter(sql_name);
                    SaveFile.WriteLine(":r \"" + textBox1.Text + "\\" + item + "\"");
                    SaveFile.Close();
                    line += item + "\n";
                    StreamReader sql = new StreamReader(sql_name);
                    //richTextBox1.Text = sr.ReadToEnd();
                    sql.Close();
                    sql.Dispose();
                    //Create a batchfile for execution of consolidated script 
                    string execute = "\\Script_Runner.bat";
                    execute = textBox1.Text + execute;
                    StreamWriter SaveFile2 = new StreamWriter(execute);
                    SaveFile2.WriteLine("sqlcmd -S localhost -E -i " + textBox1.Text + "\\" + "test1.sql");
                    //Environment.NewLine + "pause");
                    SaveFile2.Close();
                    //running the batchfile
                    string ScriptRun = "\\Script_Runner.bat";
                    ScriptRun = textBox1.Text + ScriptRun;
                    Process.Start(ScriptRun);
                    progressBar1.PerformStep();
                    this.Refresh();
                }
                richTextBox2.Text = line;
                richTextBox2.Text += "\nData Patch Completed.";
                transfer = label3.Text;
                NotificationForm NF = new NotificationForm();
                NF.Show();
            }
        }
        catch (Exception ex)
        {
            string filePath = @"C:\Error.txt";
            filePath = textBox1.Text + filePath;
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine("Message :" + ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
      }
