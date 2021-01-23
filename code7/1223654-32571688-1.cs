    using System.Globalization;
    ...
    public async Task<ActionResult> EnlistarPersonas(int? page, string fechaInicio, string fechaFin, int? idTipoPersona, string idPersona)
    {
        DateTime? fInicio = null;
        if (!string.IsNullOrEmpty(fechaInicio))
        {
            DateTime.TryParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fInicio))
        }
        DateTime? fFin = null;
        if (!string.IsNullOrEmpty(fechaFin))
        {
            DateTime.TryParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fFin))
        }
        ... The rest of your controller
    }
