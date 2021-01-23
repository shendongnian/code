                foreach (var attachment in _mimeMessage.BodyParts.OfType<MimePart>())
            {
                if (attachment.ContentId != name)
                    continue;
                using (var stream = new System.IO.MemoryStream())//File.Create(@"C:\Client Test Data\Alert Files\" + name))
                {
                    using (var filtered = new FilteredStream(stream))
                    {
                        filtered.Add(DecoderFilter.Create("base64"));
                        attachment.ContentObject.DecodeTo(filtered);
                        return stream.ToArray();
                    }
                }
            }
