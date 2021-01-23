        public static string CreateJsonFromMenuItems(IList<MenuItem> menuItems)
        {
            return new JObject
            (
                menuItems.ToTree(
                    m => (int?)m.SiteMenuId,
                    m => m.ParentId, m => new JProperty(m.MenuName, m.Url),
                    (parent, child) =>
                    {
                        if (parent.Value == null || parent.Value.Type == JTokenType.Null)
                            parent.Value = new JObject();
                        else if (parent.Value.Type != JTokenType.Object)
                            throw new InvalidOperationException("MenuItem has both URL and children");
                        child.MoveTo((JObject)parent.Value);
                    })
            ).ToString();
        }
