    public partial class...
    {
        Dictionary<TextBox, TextBox> tbPairs = new Dictionary<TextBox, TextBox>();
        private void button1_Click(...)
        {
    
        ... //create newBox1 and newBox2
    
        tbPairs[newBox1] = newBox2;   //adds the Pair to the Dictionary
        }
    }
