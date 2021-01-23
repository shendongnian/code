    using(XmlNodeList RNC_LIST = xmlDoc.GetElementsByTagName("RNC"))
	{
        foreach(XmlNode RNC in RNC_LIST)
		{
            if (RNC.Attributes["id"].Value == target_rnc)
			{
                /// Move the XmlNodes Here
            }
        }
    }
