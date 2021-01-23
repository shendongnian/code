    var elements = new[] {
        new { Control = textBox1 },
        new { Control = textBox2 }
    };
    foreach (var elem in elements)
    {
        elem.Control.BackColor = string.IsNullOrWhiteSpace(elem.Control.Text) ? Color.Yellow : Color.White;
    }
