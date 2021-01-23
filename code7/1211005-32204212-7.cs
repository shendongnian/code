           Database currentDB = Application.DocumentManager.MdiActiveDocument.Database;
            using (Transaction transaction = currentDB.TransactionManager.StartTransaction())
            {
                BlockTable blockTable = (BlockTable)transaction.GetObject(currentDB.BlockTableId, OpenMode.ForRead);
                //Create the block if it doesn't exist
                if (blockTable.Has("MyBlock"))
                {
                    //Get the block
                    ObjectId myBlockID = blockTable["MyBlock"];
                    BlockTableRecord myBlock = (BlockTableRecord)transaction.GetObject(myBlockID, OpenMode.ForRead);
                    //iterate through objects and update the attribute definition
                    if (myBlock.HasAttributeDefinitions)
                    {
                        foreach (ObjectId oid in myBlock)
                        {
                            DBObject dbObject = transaction.GetObject(oid, OpenMode.ForRead);
                            if (dbObject is AttributeDefinition)
                            {
                                AttributeDefinition attribute = (AttributeDefinition)dbObject;
                                attribute.UpgradeOpen();
                                attribute.TextString = "NewValue";
                                attribute.Constant = true;
                            }
                        }
                    }
                    //Remember... BlockRerefences are glorified pointers to the BlockTableRecord that defines them
                    //so let's get all block references associated to it and update them
                    foreach (ObjectId oid in myBlock.GetBlockReferenceIds(false, true))
                    {
                        BlockReference blockReference = (BlockReference)transaction.GetObject(oid, OpenMode.ForWrite);
                        blockReference.RecordGraphicsModified(true);
                    }
                    transaction.Commit();
                }
            }
