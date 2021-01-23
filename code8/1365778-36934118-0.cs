    using System.Linq;
    
    //...
    
    int numOfLines = 40; 
    var lines = this.textBox1.Lines;
    var newLines = lines.Take(numOfLines);
    this.textBox1.Lines = newLines.ToArray();
