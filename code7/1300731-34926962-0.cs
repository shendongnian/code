    List<string> lines = new List<string>(){/*initialization here*/}
    private void button4_Click(object sender, EventArgs e)
    {
        index = Math.Min(lines.length -1 , index + 1);
        ChangeLabelText()
    }
    private void button3_Click(object sender, EventArgs e)
    {
       index = Math.Max(0 , index - 1);
       ChangeLabelText()
    } 
    void ChangeLabelText() => label1.Text = "videos/" + lines[index] + ".mp4"; 
    
