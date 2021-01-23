     public bool GetExternBlok(string filePath, string blockName)
        {
            bool functionReturnValue = true;
            Document doc = Application.DocumentManager.MdiActiveDocument;
            using (DocumentLock  myLock = doc.LockDocument())
            {
                using (Database OpenDb = new Database(false, false))
                {
                    OpenDb.ReadDwgFile(filePath, System.IO.FileShare.Read, true, "");
                    //readwrite
                    ObjectIdCollection sourceidsCollection = new ObjectIdCollection();
                    ObjectId sourceBlockId = ObjectId.Null;
                    using (Transaction tr = OpenDb.TransactionManager.StartTransaction())
                    {
                        BlockTable bt = (BlockTable)tr.GetObject(OpenDb.BlockTableId, OpenMode.ForRead);
                        if (bt.Has(blockName))
                        {
                            sourceidsCollection.Add(bt[blockName]);
                            sourceBlockId = bt[blockName];
                        }
                      
                        if (sourceidsCollection.Count != 0)
                        {
                            Database destdb = doc.Database;
                            IdMapping iMap = new IdMapping();
                            OpenDb.WblockCloneObjects(sourceidsCollection, destdb.BlockTableId, iMap, DuplicateRecordCloning.Replace, false);
                            using (Transaction t = destdb.TransactionManager.StartTransaction())
                            {
                                ObjectId targetBlockId = ObjectId.Null;
                                BlockTable b = (BlockTable)t.GetObject(destdb.BlockTableId, OpenMode.ForRead);
                                if (b.Has(blockName))
                                {
                                    targetBlockId = b[blockName];
                                }
                              
                                t.Commit();
                            }
                        }
                        else
                        {
                            functionReturnValue = false;
                        }
                        tr.Commit();
                    }
                }
            }
            return functionReturnValue;
        }
 
