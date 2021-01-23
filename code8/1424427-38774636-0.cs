        [CommandMethod("NALATT")]
        public void ListAttributes()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = acDoc.Editor;
            Database db = acDoc.Database;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                // Start the transaction
                try
                {
                    // Build a filter list so that only
                    // block references with attributes are selected
                    TypedValue[] filList = new TypedValue[2] { new TypedValue((int)DxfCode.Start, "INSERT"), new TypedValue((int)DxfCode.HasSubentities, 1) };
                    SelectionFilter filter = new SelectionFilter(filList);
                    PromptSelectionOptions opts = new PromptSelectionOptions();
                    opts.MessageForAdding = "Select block references: ";
                    PromptSelectionResult res = ed.GetSelection(opts, filter);
                    // Do nothing if selection is unsuccessful
                    if (res.Status != PromptStatus.OK)
                        return;
                    SelectionSet selSet = res.Value;
                    ObjectId[] idArray = selSet.GetObjectIds();
                    PromptPointResult ppr;
                    PromptPointOptions ppo = new PromptPointOptions("");
                    ppo.Message = "\n Select the place for print output:";
                    //a HashSet to store printed strings to avoid duplicated values
                    HashSet<string> attValues = new HashSet<string>();
                    foreach (ObjectId blkId in idArray)
                    {
                        BlockReference blkRef = (BlockReference)tr.GetObject(blkId, OpenMode.ForRead);
                        BlockTableRecord btr = (BlockTableRecord)tr.GetObject(blkRef.BlockTableRecord, OpenMode.ForWrite);
                        ed.WriteMessage("\nBlock: " + btr.Name);
                        // get the current space (where to print the attributes values)
                        var curSpace = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
                        AttributeCollection attCol = blkRef.AttributeCollection;
                        foreach (ObjectId attId in attCol)
                        {
                            AttributeReference attRef = (AttributeReference)tr.GetObject(attId, OpenMode.ForRead);
                            string str = (attRef.TextString);
                            ed.WriteMessage("\n" + str);
                            if (attValues.Contains(str))
                                continue;
                            //get the coordinates from user
                            ppr = ed.GetPoint(ppo);
                            if (ppr.Status == PromptStatus.OK)
                            {
                                // add the mtext to current space
                                MText mtext = new MText();
                                mtext.Width = 2;
                                mtext.Location = ppr.Value;
                                mtext.Contents = str;
                                curSpace.AppendEntity(mtext);
                                tr.AddNewlyCreatedDBObject(mtext, true);
                                db.TransactionManager.QueueForGraphicsFlush();
                                // add the string to the HashSet
                                attValues.Add(str);
                            }
                        }
                    }
                    tr.Commit();
                }
                catch (Autodesk.AutoCAD.Runtime.Exception ex)
                {
                    ed.WriteMessage(("Exception: " + ex.Message));
                }
            }
        }
