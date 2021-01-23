    using (FileStream fs = File.Open(homepath + @"\Documents\DnD5e\charactersheet.json",
                                     FileMode.OpenOrCreate))
    using (StreamWriter sw = new StreamWriter(fs))
    using (JsonWriter jw = new JsonTextWriter(sw))
    {
        jw.Formatting = Formatting.Indented;
        foreach (Control ctrl in f1.Controls)
        {
            if (ctrl.Tag == "CHANGED")
            {
                jw.WritePropertyName(ctrl.Tag.ToString());
                jw.WriteValue(ctrl.Text);
            }
        }
    }
