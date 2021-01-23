    List<string> lines = new List<string>(){/*initialization here*/}
    int index = 0;
    
    private void button4_Click(object sender, EventArgs e)
    {
        //Ensure index is inside List bounds.
        index = Math.Min(lines.length -1 , index + 1);
        ChangeLabelText()
    }
    private void button3_Click(object sender, EventArgs e)
    {
       //Ensure index is inside List bounds.
       index = Math.Max(0 , index - 1);
       ChangeLabelText()
    } 
    
    void ChangeLabelText() => label1.Text = "videos/" + lines[index] + ".mp4"; 
    
