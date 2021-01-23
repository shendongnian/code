                CommandResult cr = null;
                IndexOptionsDocument NotUnique = new IndexOptionsDocument("unique", false);
                IndexKeysDocument fileNameUploadDateIdx = new IndexKeysDocument(
                    new List<BsonElement> { 
                            new BsonElement(ColumnFilename, 1), 
                            new BsonElement(ColumnUploadDate, 1) });
                var index = indexes.FirstOrDefault(
                    i => i.Key.Equals(fileNameUploadDateIdx.ToBsonDocument()));
                if (index == null)
                {
                    cr = files.CreateIndex(fileNameUploadDateIdx, NotUnique);
                    if (!cr.Ok) {
                        //Cannot create uploadDate index
                    }
                }
                else if (index.IsUnique)
                {
                    cr = files.DropIndexByName(index.Name);
                    if (!cr.Ok) {
                        // Cannot drop index filename_1_uploadDate_1. 
                    }
                    else
                    {
                        cr = files.CreateIndex(fileNameUploadDateIdx, NotUnique);
                        if (!cr.Ok) {
                        //Cannot create uploadDate index
                        }
                    }
                }
