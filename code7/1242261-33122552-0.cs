    foreach (XmlElement instrument in xml.SelectNodes("//INSTRUMENT"))
    {
        Console.WriteLine(instrument.SelectSingleNode("INSTRUMENT_CODE").InnerText);
        foreach (XmlElement analyse in instrument.SelectNodes("ANALYSES/ANALYSE"))
        {
            Console.WriteLine(analyse.SelectSingleNode("AFKORTING").InnerText);
        }
    }
