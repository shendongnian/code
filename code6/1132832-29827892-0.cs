    public void Analizar(byte[] bytes)
    {
        BinaryReader bin = new BinaryReader(new MemoryStream(bytes));
        var listado = new List<AnalisisResumenDiarioGenerico>();
        while (true)
            {
                var take = bin.ReadBytes(5);
                if (take.Count() == 0) break;
                listado.Add(ObtenerPaquete(take));
            }
        Insertar(listado);
    }
    private AnalisisResumenDiarioGenerico ObtenerPaquete(IEnumerable<byte> take)
        {
            var tipo = take.First();
            AnalisisResumenDiarioGenerico retorno;
            switch (tipo)
            {
                case 241:
                    retorno = new Velocidad(new TimeSpan(take.ToArray()[1], take.ToArray()[2], take.ToArray()[3]), take.ToArray()[4]);
                    break;
                case 242:
                    retorno = new Chofer(UltimoRD.fecha, BitConverter.ToInt32(take.ToArray(),1));
                    break;
                case 243:
                    retorno = new Odometro(UltimoRD.fecha, BitConverter.ToInt32(take.ToArray(), 1));
                    break;
                default: //nunca debería llegar acá
                    throw new FormatException();
            }
            UltimoRD = retorno;
            return retorno;
        }
