    public void Analizar(IEnumerable<byte> bytes)
    {
      var listado = new List<AnalisisResumenDiarioGenerico>();
      using (var e = bytes.GetEnumerator())
      {
        var arr = new byte[5];
        var posModFive = 0;
        while (e.MoveNext())
        {
          arr[posModFive] = e.Current;
          posModFive++;
          if (posModFive == 5)
          {
            listado.Add(ObtenerPaquete(arr));
            posModFive = 0;
          }
        }
        if (posModFive != 0) { /* Hey, 5 did not divide the total length! */ }
      }
      //InsertInDB(listado);
    }
