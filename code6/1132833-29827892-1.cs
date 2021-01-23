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
            var data = take.ToArray();
            AnalisisResumenDiarioGenerico retorno;
            switch (tipo)
            {
                case 241:
                    retorno = new Velocidad(new TimeSpan(data[1], data[2], data[3]),data[4]);
                    break;
                case 242:
                    retorno = new Chofer(UltimoRD.fecha, BitConverter.ToInt32(data,1));
                    break;
                case 243:
                    retorno = new Odometro(UltimoRD.fecha, BitConverter.ToInt32(data, 1));
                    break;
                default: //nunca debería llegar acá
                    throw new FormatException();
            }
            UltimoRD = retorno;
            return retorno;
        }
