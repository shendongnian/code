    var result = doc.Root
                    .Elements()
                    .Select(o => new
                    {
                        maxDepth = o.Descendants("Depth").Max(x => (double)x),
                        maxWidth = o.Descendants("Width").Max(x => (double)x),
                        maxHeight = o.Descendants("Height").Max(x => (double)x)
                    })
                    .ToList();
				
