            Database currentDB = Application.DocumentManager.MdiActiveDocument.Database;
            using (Transaction transaction = currentDB.TransactionManager.StartTransaction())
            {
                BlockTable blockTable = (BlockTable)transaction.GetObject(currentDB.BlockTableId, OpenMode.ForRead);
                //Create the block if it doesn't exist
                if (!blockTable.Has("MyBlock"))
                {
                    using (BlockTableRecord myBlock = new BlockTableRecord())
                    {
                        myBlock.Name = "MyBlock";
                        myBlock.Origin = Point3d.Origin;
                        //You can add geometry here, but I'm just going to create the attribute
                        using (AttributeDefinition attribute = new AttributeDefinition())
                        {
                            attribute.Position = Point3d.Origin;
                            attribute.Tag = "Constant";
                            attribute.Prompt = "Enter value: ";
                            attribute.TextString = "My value";
                            attribute.Height = 0.5;
                            attribute.Justify = AttachmentPoint.BottomLeft;
                            attribute.Constant = true;
                            myBlock.AppendEntity(attribute);
                            //add to the block table
                            blockTable.UpgradeOpen();
                            blockTable.Add(myBlock);
                            transaction.AddNewlyCreatedDBObject(myBlock, true);
                        }
                    }
                    transaction.Commit();
                }
            }
