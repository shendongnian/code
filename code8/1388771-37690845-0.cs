        public static void AddMediaType()
        {
            MediaType mediaType = new MediaType(-1);
            mediaType.AllowedAsRoot = true;
            mediaType.Name = NAME;
            mediaType.Description = "Container for the Social Media Channel Theme Images";
            mediaType.IsContainer = true;
            mediaType.Icon = "icon-picture";
            mediaType.Alias = ALIAS;
            //Allowed child nodes
            var children = new List<ContentTypeSort>
                {
                    new ContentTypeSort(FOLDER_ID, 0),
                    new ContentTypeSort(IMAGE_ID, 1)
                };
            mediaType.AllowedContentTypes = children;
            DataTypeService dataTypeService = (DataTypeService)ApplicationContext.Current.Services.DataTypeService;
            //Add properties
            var name = new PropertyType(dataTypeService.GetDataTypeDefinitionById(TEXT_ID), "themeName");
            name.Name = "Theme Name";
            name.Description = "Name for the theme";
            name.SortOrder = 0;
            var url = new PropertyType(dataTypeService.GetDataTypeDefinitionById(TEXT_ID), "themeUrl");
            url.Name = "Theme Url";
            url.Description = "Url for the original theme";
            url.SortOrder = 1;
            var createdBy = new PropertyType(dataTypeService.GetDataTypeDefinitionById(TEXT_ID), "createdBy");
            createdBy.Name = "Created By";
            createdBy.Description = "Theme Author";
            createdBy.SortOrder = 2;
            var createdDate = new PropertyType(dataTypeService.GetDataTypeDefinitionById(DATE_ID), "createdDate");
            createdDate.Name = "Created Date";
            createdDate.Description = "Date the Theme was created";
            createdDate.SortOrder = 3;
            mediaType.AddPropertyType(name, "Image");
            mediaType.AddPropertyType(url, "Image");
            mediaType.AddPropertyType(createdBy, "Image");
            mediaType.AddPropertyType(createdDate, "Image");
            ContentTypeService contentTypeService = (ContentTypeService)ApplicationContext.Current.Services.ContentTypeService;
            contentTypeService.Save(mediaType);
        }
