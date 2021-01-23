        /// <summary>
        /// Methode de deserialisation d'objets
        /// </summary>
        /// <param name="xmlObject">Document XML à désérialiser</param>
        /// <returns>Retourne l'objet chargé avec les données du document XML passé en paramètres</returns>
    public static ObjectTypeT Deserialize(XmlDocument xmlObject)
    {
        if (xmlObject == null)
            throw new NullXmlDocumentException();
        if (xmlObject.DocumentElement == null)
            throw new NullXmlDocumentElementException();
        using (XmlNodeReader reader = new XmlNodeReader(xmlObject.DocumentElement))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObjectTypeT));
            return (ObjectTypeT)serializer.Deserialize(reader);
        }
    }
