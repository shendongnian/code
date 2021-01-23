    var embarcaciones = itemsEmbarcaciones.Select(item => new Embarcaciones
        {
            Categoria = idioma == "Espanol" ?
            item["Categoria"] == null ? string.Empty :
                     ((Microsoft.SharePoint.Client.FieldLookupValue)(item["Categoria"])).LookupValue
            : item["Categoria_x003a_English"] == null ? string.Empty :
                    ((Microsoft.SharePoint.Client.FieldLookupValue)(item["Categoria_x003a_English"])).LookupValue,
    
            Title = item["Title"] == null ? string.Empty : item["Title"].ToString(),
            Imagen = item["Imagen"] == null ? string.Empty : (item["Imagen"] as FieldUrlValue).Url,
            Enlace = item["Enlace"] == null ? string.Empty : item["Enlace"].ToString(),
            Especificaciones = item["Especificaciones"] == null ? string.Empty : item["Especificaciones"].ToString(),
            Specifications = item["Specifications"] == null ? string.Empty : item["Specifications"].ToString()
        }).ToList();
