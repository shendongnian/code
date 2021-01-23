    public class MySampleMetadataAttribue : Attribute, IMetadatAttribute
    {
        public Attribute[] Process()
        {
            var attributes = new Attribute[]{ 
                new BrowsableAttribute(false),
                new EditorBrowsableAttribute(EditorBrowsableState.Never), 
                new BindableAttribute(false),
                new DesignerSerializationVisibilityAttribute(
                        DesignerSerializationVisibility.Hidden),
                new ObsoleteAttribute("", true)
            };
            return attributes;
        }
    }
