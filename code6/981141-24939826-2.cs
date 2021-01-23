    private void Form1_Load(object sender, EventArgs e)
    {
        SetBackColor("button1.BackColor = Color.Black");
    }
    
    public void SetBackColor(string statement)
    {
        var controlName = Regex.Match(statement, "(.+?)\\.").Groups[1].Value;
        var colorName = Regex.Match(statement, "Color\\.(.+)").Groups[1].Value;
        
        // Todo: ensure that each of the aforementioned matches were successful.    
  
        var control = Controls.Find(controlName, true).FirstOrDefault();
        if (control == null) {
            throw new InvalidOperationException("Control X does not exist.");
        }
    
        var property = (Color) typeof (Color).GetProperty(colorName).GetValue(null);
        control.BackColor = property;
    }
