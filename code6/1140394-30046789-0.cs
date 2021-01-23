    // A mock but the idea is the same            
    var tx = new[] { new TextBox { Text = "1" }, new TextBox { Text = "2" }, new TextBox { Text = "" }, new TextBox { Text = "3" } };
    var sum = 0;
    foreach (TextBox t in tx) {
        var temp = 0;
        if (Int32.TryParse(t.Text, out temp)) {
            sum += temp; 
        }
    }
    Console.WriteLine(sum);
