    public static ValidationResult validaUsuariosNaLista(Reuniao item)
    {
        var isValid = s => s.Select(x => string.IsNullOrWhiteSpace(x.Login)).Any();
        //does every item have a value?
        if (isValid(item.Requeridos) || isValid(item.Informados) || isValid(item.Opcionais))
            return new ValidationResult(Resources.Validations.ValidaUsuarioMesmaLista);
        //are all of the items unique?
        if (item.Requeridos.Count() + item.Informados.Count() + item.Opcionais.Count() > 
              item.Requeridos.Concat(item.Informados).Concat(item.Opcionais).Distinct().Count)
        {
           //some items are duplicated
        }
    
        return ValidationResult.Success;
    }
