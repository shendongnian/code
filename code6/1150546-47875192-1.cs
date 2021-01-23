    public int GuardarAsociacionesBonos(List<O_Bono_ConfiguracionPago> bonos)
    {
        if (!bonos.Any()) return bonos.Count;
        O_Bono_ConfiguracionPago existe;
        using (var contexto = new TouchERPEntities())
        {
            foreach (var bono in bonos)
            {
                existe = contexto.O_Bono_ConfiguracionPago.SingleOrDefault(x => x.IDBono == bono.IDBono && x.IDConfiguracionPago == bono.IDConfiguracionPago);
                if (existe.IDBonoConfigPago != 0)
                {
                    bono.IDBonoConfigPago = existe.IDBonoConfigPago;
                    contexto.Entry(existe).CurrentValues.SetValues(bono);
                }
                else
                {
                    contexto.O_Bono_ConfiguracionPago.Add(bono);
                }
            }
            contexto.SaveChanges();
        }
        return bonos.Count;
    }
