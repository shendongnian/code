            using (var sr = new StringReader(xml))
            using (var reader = XmlReader.Create(sr))
            {
                foreach (var dict in StreamNamedElements(reader, new[] { (XName)"SponsorID", (XName)"Contract" }))
                {
                    XElement sponsorID;
                    XElement contract;
                    if (!dict.TryGetValue("SponsorID", out sponsorID))
                        continue;
                    if (!dict.TryGetValue("Contract", out contract))
                        continue;
                    // Example "higher processing"
                    Debug.WriteLine(string.Format("{0}: {1}", sponsorID.Value, contract.ToString()));
                }
            }
