    string[] lines = new string[NN[0].Count]; // assume all lines have equal length
    for(int i = 0; i < NN.Count; ++i) {
      for(int j = 0; j < NN[i].Count; ++j) {
         lines[j] += NN[i][j] + ((i==NN.Count - 1) ? "" : ",");
      }
    }
    File.WriteAllLines("path.csv", lines);
