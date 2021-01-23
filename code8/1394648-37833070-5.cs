      double[] weights = new double[] {1.2, 3.58, 4.62, -1.7, 0.9};
      double result = new [] {groupBox1, groupBox2, groupBox3, groupBox4, groupBox5}
        .Select((box, index) => new {
           box = box,
           weight = weights[index] 
         }  
        .Where(item => item.box.Controls
           .OfType<RadioButton>()
           .Any(button => button.Checked))
        .Sum(item => item.weight);
