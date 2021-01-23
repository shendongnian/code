    public class ReuniaoValidation
        {
            public static ValidationResult validaUsuariosNaLista(Reuniao item)
            {
                var requeridos = item.Requeridos.Select(x => string.IsNullOrWhiteSpace(x.Login)).Any();
                var informados = item.Informados.Select(x => string.IsNullOrWhiteSpace(x.Login)).Any();
                var opcionais = item.Opcionais ?? Enumerable.Empty<MeetingUser>();
    
                var listasCombinadas = (item.Requeridos.Concat(item.Informados)).Concat(item.Opcionais ?? Enumerable.Empty<MeetingUser>());
                
                if (listasCombinadas.GroupBy(x => x.Login).Any(gr => gr.Count() > 1))
                {
                    item.AddOdm = false;
                    return new ValidationResult(Resources.Validations.ValidaUsuarioMesmaLista);                
                }
    
                return ValidationResult.Success;
            }
