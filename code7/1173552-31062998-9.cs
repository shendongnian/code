            using (var sr = new StringReader(xml))
            using (var reader = XmlReader.Create(sr))
            {
                foreach (var subReader in StreamNamedSubtrees(reader, new[] { (XName)"Sponsor" }))
                {
                    XElement sponsorID = null;
                    foreach (var el in StreamNamedElements(subReader, new[] { (XName)"SponsorID", (XName)"Contract" }))
                    {
                        if (el.Name == "SponsorID")
                        {
                            sponsorID = el;
                        }
                        else if (el.Name == "Contract")
                        {
                            if (sponsorID == null)
                                throw new InvalidOperationException();
                            // Example "higher processing"
                            Debug.WriteLine(string.Format("{0}: {1}", sponsorID.Value, el.ToString()));
                        }
                    }
                }
            }
