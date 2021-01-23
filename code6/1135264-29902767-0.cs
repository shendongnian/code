    List<Color> C;
    Int32 counter = 0;
    
    private void Form1_Load(object sender, EventArgs e)
            {
                C = new List<Color>();
                C.Add(Color.AliceBlue);
                C.Add(Color.AntiqueWhite);
                C.Add(Color.Aqua);
                C.Add(Color.Aquamarine);
                C.Add(Color.Azure);
                C.Add(Color.Beige);
                C.Add(Color.Black);
                C.Add(Color.BlanchedAlmond);
                C.Add(Color.Blue);
                C.Add(Color.BlueViolet);
            }
    
    private void richTextBox1_TextChanged(object sender, EventArgs e)
            {
                //richTextBox1.SelectionStart = 1;
                //richTextBox1.SelectionLength = mystring.Length;
                richTextBox1.SelectionColor = C[counter];
                counter++;
                if (counter >= 10)
                {
                    counter = 0;
                }
            }
