    public static ValidationResult validaUsuariosNaLista(Reuniao item)
    {
        var isValid = s => s.Select(x => string.IsNullOrWhiteSpace(x.Login)).Any();
        if (isValid(item.Requeridos) || isValid(item.Informados) || isValid(item.Opcionais))
            return new ValidationResult(Resources.Validations.ValidaUsuarioMesmaLista);
    
        return ValidationResult.Success;
    }
