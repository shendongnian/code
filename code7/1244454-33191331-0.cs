    AutoMapper.Mapper.CreateMap<XmlDocument,Result>()
        .ForAllMembers(opt => opt.ResolveUsing(res =>
        {
            XmlDocument document = (XmlDocument)res.Context.SourceValue;
            var node = document
                .DocumentElement
                .ChildNodes
                .OfType<XmlElement>()
                .FirstOrDefault(
                    element =>
                        element
                        .GetAttribute("ID")
                        .Equals(res.Context.MemberName, StringComparison.OrdinalIgnoreCase));
            if (node == null)
                throw new Exception("Could not find a corresponding node in the XML document");
            return node.InnerText;
        }));
