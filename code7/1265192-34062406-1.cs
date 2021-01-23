    List<Art> items = DocumentDbHelper.Client.CreateDocumentQuery<Art>(collection.DocumentsLink)
                                   .Where(i => i.type == "art")
                                   .AsEnumerable() // The context switch!
                                   .Where(i => i.Products.Any(p => p.Name == productType))
                                   .ToList();
