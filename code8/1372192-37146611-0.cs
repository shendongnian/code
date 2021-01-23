    public static void log_serial(string input_text)
    {
        string text = input_text;
        string filepath = Globals.savePath
                        + "\\" + Globals.FileName_Main
                        + ".text";
        try
        {
            using (var sw = System.IO.File.AppendText(filepath))
            {
                sw.WriteLine(input_text);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
