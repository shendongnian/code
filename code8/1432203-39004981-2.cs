    using Microsoft.SharePoint.Client;
    
    //...
    var embarcaciones = itemsEmbarcaciones.Select(item => new Embarcaciones
        {
            Categoria = idioma == "Espanol" 
                           ? (item["Categoria"] as FieldLookupValue)?.LookupValue ?? string.Empty
                           : (item["Categoria_x003a_English"] as FieldLookupValue)?.LookupValue ?? string.Empty,
    
            Title = item["Title"] as string ?? string.Empty,
            Imagen = (item["Imagen"] as FieldUrlValue)?.Url ?? string.Empty,
            Enlace = item["Enlace"] as string ?? string.Empty,
            Especificaciones = item["Especificaciones"] as string ?? string.Empty,
            Specifications = item["Specifications"] as string ?? string.Empty
        }).ToList();
