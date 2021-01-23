    public void DeSerialize()
    {
        _ModelData = new OCLMModelData();
        XmlSerializer x = new XmlSerializer(_ModelData.GetType());
        using (StreamReader reader = new StreamReader(_strPathModelDataXml))
        {
            _ModelData = (OCLMModelData)x.Deserialize(reader);
        }
        _ModelData.MarkClean();
    }
