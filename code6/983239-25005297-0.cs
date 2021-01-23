    XElement res = XElement.Parse(xmlResult);
    foreach(var elem in res.Element("PVCAPTUREJOBSTATISTICS").Elements("PVCAPTURESTATISTICSUMMARY"))
    {
        if (elem.Element("STATISTICTYPE").Value.Equals("PVCAP_CharactersSaved", StringComparison.Ordinal))
        {
            string jobName = elem.Element("JOBNAME").Value;
            string timeDelta = elem.Element("TIMEDELTA").Value;
            string valueSum = elem.Element("VALUESUM").Value;
        }
    }
