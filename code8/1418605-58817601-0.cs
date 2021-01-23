    protected override void PostFilterAttributes(IDictionary attributes)
        {
            base.PostFilterAttributes(attributes);
            var oDockingAttribute = attributes.Values.OfType<DockingAttribute>().FirstOrDefault();
            var oNoDockingAttribute = new DockingAttribute(DockingBehavior.Never);
            if (oDockingAttribute != null) attributes[oDockingAttribute.TypeId] = oNoDockingAttribute;
        }
