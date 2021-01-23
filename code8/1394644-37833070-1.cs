    var result = new [] {groupBox1, groupBox2, groupBox3, groupBox4, groupBox5}
      .Select((box, index) => new {
        box = box,
        mask = 1 << index
      }) 
      .Where(item => item.box.Controls
        .OfType<RadioButton>()
        .Any(button => button.Checked))
      .Sum(item => item.mask);
