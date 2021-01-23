            XDocument doc = XDocument.Load(String.Format(@"{0}\{1}", settingsDir, settingsFilename));
            var query = doc.Descendants("Schedule");
            var q2 = query.Descendants("Period").Where(a => a.Value == period.ToString()).Select(b => b);
            if (q2.Count() == 0)
            {
                query.FirstOrDefault().Add(new XElement("Period", period.ToString()));
                doc.Save(String.Format(@"{0}\{1}", settingsDir, settingsFilename));
            }
