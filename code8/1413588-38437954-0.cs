    var lines1 = textBox1.Lines.Where(s => !string.IsNullOrWhiteSpace(s));
    var lines2 = textBox2.Lines.Where(s => !string.IsNullOrWhiteSpace(s));
    textBox1.Lines = lines1.Union(lines2).ToArray();
    textBox3.Lines = lines2.Except(lines1).ToArray();
    
    // If you need to append the non-duplicate contents instead of replacing
    // it in the textBox3, remove the previous operation and uncomment the
    // following line:
    //textBox3.Lines = textBox3.Lines.Concat(lines2.Except(lines1)).ToArray();
