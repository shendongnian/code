    private string findBetweenMethod(string text, string start, string end){
        string betweenText = text;
        .... //process
        return betweenText;
    }
    private void button2_Click_1(object sender, EventArgs e)
    {
        var abc = findBetweenMethod(textBox1.Text,"abc", "&"); //find what to change
        textBox1.Text = textBox1.Text.Replace(abc, "any"); //change it, assign it back to the textBox1
        var def = findBetweenMethod(textBox1.Text,"def", "&"); 
        textBox1.Text = textBox1.Text.Replace(def, "any");
        var ghi = findBetweenMethod(textBox1.Text,"ghi", "&"); 
        textBox1.Text = textBox1.Text.Replace(ghi, "any");
        var jkl = findBetweenMethod(textBox1.Text,"jkl", "&"); 
        textBox1.Text = textBox1.Text.Replace(jkl, "any");
    }
