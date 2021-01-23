    Public Enum EXIFProperty
        Title = 40091
        Author = 40093
        Keywords = 40094
        Comments = 40092
    End Enum
    Dim exifProperty As EXIFProperty
    Dim propertyItem As PropertyItem
    propertyItem.Id = CInt(exifProperty.Title)
