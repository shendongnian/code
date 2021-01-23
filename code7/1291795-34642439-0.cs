    foreach (XElement prompt in voiceXmlDocument.Descendants("prompt"))
    {
        string text = prompt.Value;  
        prompt.RemoveAll();
        foreach (string phrase in text.Split('['))
        {
            string[] parts = phrase.Split(']');
            if (parts.Length > 1)
            {
                string[] pause = parts[0].Split('=');
                prompt.Add(new XElement("break", new XAttribute("time", pause[1])));
                // add a + "s" if you REALLY want it, but then you have to get rid
                // of it later in some other code.
            }
            prompt.Add(new XText(parts[parts.Length - 1]));
        }
    }
