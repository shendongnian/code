    if (txtopen.ShowDialog() == DialogResult.OK) {
      var result = File
        .ReadLines(txtopen.FileName)
        .Select(item => Double.Parse(item, CultureInfo.InvariantCulture));
 
      // if you need List<Double> from read values:
      //   List<Double> data = result.ToList();
      // To append existing list:
      //   list.AddRange(result);
    
      Console.Write(String.Join(Environment.NewLine, result));
    }
