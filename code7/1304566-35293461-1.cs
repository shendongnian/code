    public IEnumerable<Seminario> Listarseminariomodal()
    {
        IEnumerable<Seminario> seminariolista = null;
        try
        {
            using (var ctx = new ProyectoContext_())
            {
                seminariolista = ctx.Seminario.Where(x => x.modal == 1)
                .OrderBy(x => x.orden);
            }
        }
        catch (Exception)
        {
            throw;
        }
        return seminariolista.ToArray();
    }
