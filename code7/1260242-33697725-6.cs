    public static ValidationResult validaUsuariosNaLista(Reuniao item)
    {
        var requeridos = item.Requeridos.Any(x => string.IsNullOrWhiteSpace(x.Login));
        var informados = item.Informados.Any(x => string.IsNullOrWhiteSpace(x.Login));
        var opcionais  = item.Opcionais .Any(x => string.IsNullOrWhiteSpace(x.Login));
        //does every item have a value?
        if (requeridos || informados || opcionais)
            return new ValidationResult(Resources.Validations.ValidaUsuarioMesmaLista);
        //are all of the items unique?
        if (item.Requeridos.Count() + item.Informados.Count() + item.Opcionais.Count() > 
              item.Requeridos.Concat(item.Informados).Concat(item.Opcionais).Distinct().Count)
        {
           //some items are duplicated
        }
    
        return ValidationResult.Success;
    }
