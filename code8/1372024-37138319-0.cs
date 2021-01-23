    for (int i = 0; i < correctionQoutas.Count; i++)
    {
      if (correctionQoutas[i].Value % 1 != 0) //Value = 2.88888889
      {
        correctionQoutas[i].Value = math.Round(correctionQoutas[i].Value, 1); // Want to assign 2.8
      }
    }
