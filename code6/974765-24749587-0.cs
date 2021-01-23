        [ProvideProperty("Link", typeof(Control))]
        public class ExtendControls : Component, IExtenderProvider
        {
            private Dictionary<Control, string> links =
                                       new Dictionary<Control, string>();
    
            public bool CanExtend(object extendee)
            {
                return !(extendee is Form);
            }
    
            public void SetLink(Control extendee, string value)
            {
                if (value.Length == 0)
                {
                    links.Remove(extendee);
                }
                else
                { 
                    links[extendee] = value; 
                }
            }
    
            [DisplayName("Link")]
            [ExtenderProvidedProperty()]
            public string GetLink(Control extendee)
            {
                if (links.ContainsKey(extendee))
                {
                    return links[extendee];
                }
                else
                {
                    return string.Empty;
                }
            }
        }
