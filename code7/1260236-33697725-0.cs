    public static ValidationResult validaUsuariosNaLista(Reuniao item)
    {
        var requeridos = item.Requeridos.Select(x => string.IsNullOrWhiteSpace(x.Login)).Any();
        var informados = item.Informados.Select(x => string.IsNullOrWhiteSpace(x.Login)).Any();
        var opcionais  = item.Opcionais .Select(x => string.IsNullOrWhiteSpace(x.Login)).Any();
        if (requeridos || informados || opcionais)
            return new ValidationResult(Resources.Validations.ValidaUsuarioMesmaLista);
    
        return ValidationResult.Success;
    }
