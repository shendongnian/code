    namespace Project.Models
    {
        public class ProjectMimeType : ProjectEntity
        {
            public mime_types EntityMimeType = new mime_types(); // Entity Object
    
            // begin direct db map
    
            public long Id
            {
                get { return EntityMimeType.mime_type_id; }
                set { EntityMimeType.mime_type_id = value; }
            }
    
            public string Label
            {
                get { return EntityMimeType.label; }
                set
                {
                    EntityMimeType.label = value;
                    EntityMimeType.ulabel = value.ToUpper();
                }
            }
    
            public string Ulabel => EntityMimeType.ulabel;
    
            public string MimeType
            {
                get { return EntityMimeType.mime_type; }
                set { EntityMimeType.mime_type = value; }
            }
    
            public string DefaultExtension
            {
                get { return EntityMimeType.default_extension; }
                set { EntityMimeType.default_extension = value; }
            }
        }
    }
