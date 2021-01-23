        using (FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader r = new StreamReader(fs))
                {
                    this.MyCheckBox.Enabled = Convert.ToBoolean(r.ReadLine());
                }
            }
