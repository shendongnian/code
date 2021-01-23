        // Set up some formatting constants
        // for the table
        private const double colWidth = 15.0;
        private const double rowHeight = 3.0;
        private const double textHeight = 1.0;
        private const CellAlignment cellAlign = CellAlignment.MiddleCenter;
        // Helper function to set text height
        // and alignment of specific cells,
        // as well as inserting the text
        static public void SetCellText(Table tb, int row, int col, string value)
        {
            tb.Cells[row, col].Alignment = cellAlign;
            tb.Cells[row, col].TextHeight = textHeight;
            tb.Cells[row, col].Value = value;
        }
        [CommandMethod("BAT")]
        static public void BlockAttributeTable()
        {
            Document doc = AcAp.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            PromptStringOptions opt = new PromptStringOptions("\nEnter name of block to list: ");
            PromptResult pr = ed.GetString(opt);
            if (pr.Status == PromptStatus.OK)
            {
                string blockToFind = pr.StringResult.ToUpper();
                Transaction tr = doc.TransactionManager.StartTransaction();
                using (tr)
                {
                    // Let's check the block exists
                    BlockTable bt = (BlockTable)tr.GetObject(doc.Database.BlockTableId, OpenMode.ForRead);
                    if (!bt.Has(blockToFind))
                    {
                        ed.WriteMessage("\nBlock " + blockToFind + " does not exist.");
                    }
                    else
                    {
                        // And go through looking for
                        // attribute definitions
                        StringCollection colNames = new StringCollection();
                        BlockTableRecord bd = (BlockTableRecord)tr.GetObject(bt[blockToFind], OpenMode.ForRead);
                        foreach (ObjectId adId in bd)
                        {
                            DBObject adObj = tr.GetObject(adId, OpenMode.ForRead);
                            // For each attribute definition we find...
                            AttributeDefinition ad = adObj as AttributeDefinition;
                            if (ad != null)
                            {
                                // ... we add its name to the list
                                colNames.Add(ad.Tag);
                                ed.WriteMessage("\n" + ad.Tag);
                            }
                        }
                        if (colNames.Count == 0)
                        {
                            ed.WriteMessage("\nThe block " + blockToFind + " contains no attribute definitions.");
                        }
                        else
                        {
                            // Ask the user for the insertion point
                            // and then create the table
                            PromptPointResult ppr;
                            PromptPointOptions ppo = new PromptPointOptions("");
                            ppo.Message = "\n Select the place for print output:";
                            //get the coordinates from user
                            ppr = ed.GetPoint(ppo);
                            if (ppr.Status != PromptStatus.OK)
                                return;
                            Point3d startPoint = ppr.Value.TransformBy(ed.CurrentUserCoordinateSystem);
                            //Point3d startPoint1 = startPoint.Subtract();
                            Vector3d disp = new Vector3d(0.0, -2.0 * db.Textsize, 0.0);
                            Vector3d disp2 = new Vector3d(0.0, -2.0 * db.Textsize, 0.0);
                            if (ppr.Status == PromptStatus.OK)
                            {
                                Table tb = new Table();
                                tb.TableStyle = db.Tablestyle;
                                tb.SetSize(2, colNames.Count);
                                tb.SetRowHeight(rowHeight);
                                tb.SetColumnWidth(colWidth);
                                tb.Position = startPoint;
                                // Let's add the table title
                                tb.Cells[0, 0].Value = bd.Name;
                                // Let's add our column headings
                                for (int i = 0; i < colNames.Count; i++)
                                {
                                    SetCellText(tb, 1, i, colNames[i]);
                                    //ed.WriteMessage("\n" + colNames[i]);
                                }
                                // Now let's search for instances of
                                // our block in the modelspace
                                ObjectId msId = SymbolUtilityServices.GetBlockModelSpaceId(db);
                                BlockTableRecord ms = (BlockTableRecord)tr.GetObject(msId, OpenMode.ForWrite);
                                int rowNum = 2;
                                foreach (ObjectId brId in bd.GetBlockReferenceIds(true, true))
                                {
                                    BlockReference br = (BlockReference)tr.GetObject(brId, OpenMode.ForRead);
                                    if (br.OwnerId == msId)
                                    {
                                        // We have found one of our blocks,
                                        // so add a row for it in the table
                                        tb.InsertRows(rowNum, rowHeight, 1);
                                        // Assume that the attribute refs
                                        // follow the same order as the
                                        // attribute defs in the block
                                        int attNum = 0;
                                        foreach (ObjectId arId in br.AttributeCollection)
                                        {
                                            DBObject arObj = tr.GetObject(arId, OpenMode.ForRead);
                                            AttributeReference ar = arObj as AttributeReference;
                                            if (ar != null)
                                            {
                                                string strCell = ar.TextString;
                                                string strArId = arId.ToString().Trim('(', ')');
                                                SetCellText(tb, rowNum, attNum, strCell);
                                                ed.WriteMessage("\n" + ar.Tag);
                                            }
                                            attNum++;
                                        }
                                        rowNum++;
                                    }
                                }
                                tb.GenerateLayout();
                                ms.AppendEntity(tb);
                                tr.AddNewlyCreatedDBObject(tb, true);
                                tr.Commit();
                            }
                        }
                    }
                }
            }
        }
