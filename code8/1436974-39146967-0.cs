    public void SetLineChartData()
    {
        int[] yourIntArray; // your int array
        //Suppose we have a list of 60 items.
        using (ZigBeeContext db = new ZigBeeContext())
        {
            var lista = (from p in db.Medidas
                            select new Medida
                            {
                                Fecha = p.FechaHora,
                            }).ToList();
            // here is how you can do that
            yourIntArray = lista.Select(x => 
                            x.FechaHora //i think that's property that you need to be in int array
                            ).ToArray();
        }
    }
