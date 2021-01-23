        private void button1_Click(object sender, EventArgs e)
        {
          Form1.WriteToFile(textBox1, textBox2, textBox3, checkBox);
        }
        private static void WriteToFile(params Control[] controls)
        {
            string accountsSettingsFile = Path.GetDirectoryName(Application.LocalUserAppDataPath)
            + "\\accounts" + "\\accounts.txt";
            List<string> lines = new List<string>(controls.Length);
            foreach (var control in controls)
            {
                string value = Form1.GetValueFromControl(control);
                if (value != null)
                    lines.Add(value);
            }
            
            //This will overwrite the file. If you want to append
            //use File.AppendAllLines
            File.WriteAllLines(accountsSettingsFile, lines);
        }
        private static string GetValueFromControl(Control control)
        {
            if (control is TextBox)
            {
                return ((TextBox)control).Text;
            }
            if (control is CheckBox)
            {
                return ((CheckBox)control).Checked.ToString();
            }
            return null;
        }
