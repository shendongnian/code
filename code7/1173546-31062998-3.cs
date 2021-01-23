            using (var sr = new StringReader(xml))
            using (var reader = XmlReader.Create(sr))
            {
                foreach (var subReader in StreamNamedSubtrees(reader, new[] { (XName)"Sponsor" }))
                {
                    foreach (var dict in StreamNamedElements(reader, new[] { (XName)"SponsorID", (XName)"Contract" }))
                    {
                        XElement sponsorID;
                        XElement contract;
                        if (!dict.TryGetValue("Contract", out contract))
                            continue;
                        sponsorID = dict["SponsorID"]; // SponsorID must be present BEFORE Contract, throw an exception if not!
                        // Example "higher processing"
                        Debug.WriteLine(string.Format("{0}: {1}", sponsorID.Value, contract.ToString()));
                    }
                }
            }
