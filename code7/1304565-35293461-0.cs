    public IEnumerable<Seminario> Listarseminariomodal()
    {
        var seminariolista = new List<Seminario>();
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
