    public static ValidationResult validaUsuariosNaLista(Reuniao item)
    {
        var HasEmptyValue = s => s.Any(x => string.IsNullOrWhiteSpace(x.Login));
        //does every item have a value?
        if (HasEmptyValue(item.Requeridos) || HasEmptyValue(item.Informados) || HasEmptyValue(item.Opcionais))
            return new ValidationResult(Resources.Validations.ValidaUsuarioMesmaLista);
        //are all of the items unique?
        if (item.Requeridos.Count() + item.Informados.Count() + item.Opcionais.Count() > 
              item.Requeridos.Concat(item.Informados).Concat(item.Opcionais).Distinct().Count)
        {
           //some items are duplicated
        }
    
        return ValidationResult.Success;
    }
