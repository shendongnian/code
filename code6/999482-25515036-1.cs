    public static void ReadXml(ref Duration it, XmlReader reader)
    {
        reader.MoveToContent();
        it.Value = reader.GetAttribute<float>(XML_VALUE);
        it.Unit = reader.GetAttribute<DurationUnit>(XML_UNIT);
    }
