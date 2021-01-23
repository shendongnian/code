    string[] lines = new string[NN[0].Length]; // assume all lines have equal length
    for(int i = 0; i < NN.Length; ++i) {
      for(int j = 0; j < NN[i].Length; ++j) {
         lines[j] += NN[i][j] + ((i==NN.Length - 1) ? "" : ",");
      }
    }
    File.WriteAllLines("path.csv", lines);
