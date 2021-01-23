        [CommandMethod("ATT")]
        public void ListAttributes()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = acDoc.Editor;
            Database db = acDoc.Database;
            // build the begining of the text from the filename
            string filename = Path.GetFileNameWithoutExtension(acDoc.Name);
            string pattern = @"^(?<code>\w+)-[CSDWM](?<phase>\d+)(?<zone>[A-Z])-\w+$";
            //  pattern description:
            //  ^(?<code>\w+)   'code' named group: one or more word characters at the begining
            //  -               one hyphen (literal)
            //  [CSDWM]         one alphabetic character (C, S, D, W or M)
            //  (?<phase>\d+)   'phase' named group: one or more digits
            //  (?<zone>[A-Z])  'zone' named group: one alphabetic character
            //  -               one hyphen (literal)
            //  \w+$            one or more world characters at the end
            Match match = Regex.Match(filename, pattern);
            if (!match.Success)
            {
                ed.WriteMessage("\n The document file name does not match the pattern.");
                return;
            }
            var groups = match.Groups;
            string text = $"Project:{groups["code"]} Phase:{groups["phase"]} Zone:{groups["zone"]}";
            // Build a filter list so that only "NAL-SCRTAG"
            // block references are selected
            TypedValue[] filList = new TypedValue[2] { new TypedValue(0, "INSERT"), new TypedValue(2, "NAL-SCRTAG") };
            SelectionFilter filter = new SelectionFilter(filList);
            PromptSelectionOptions opts = new PromptSelectionOptions();
            opts.MessageForAdding = "Select block references: ";
            PromptSelectionResult res = ed.GetSelection(opts, filter);
            // Do nothing if selection is unsuccessful
            if (res.Status != PromptStatus.OK)
                return;
            //get the coordinates from user
            PromptPointOptions ppo = new PromptPointOptions("\n Select the place for print output: ");
            PromptPointResult ppr = ed.GetPoint(ppo);
            if (ppr.Status != PromptStatus.OK)
                return;
            Point3d startPoint = ppr.Value.TransformBy(ed.CurrentUserCoordinateSystem);
            // Start the transaction
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // use a HashSet to avoid duplicated values
                    HashSet<string> attValues = new HashSet<string>();
                    // add the attributes values at the end of the text
                    foreach (ObjectId blkId in res.Value.GetObjectIds())
                    {
                        BlockReference blkRef = (BlockReference)tr.GetObject(blkId, OpenMode.ForRead);
                        foreach (ObjectId attId in blkRef.AttributeCollection)
                        {
                            AttributeReference attRef = (AttributeReference)tr.GetObject(attId, OpenMode.ForRead);
                            string str = (attRef.TextString);
                            if (attValues.Add(str)) // returns false if attValues already contains str
                            {
                                text += $" ({str})"; // adds the attribute text string at the end of the text
                            }
                        }
                    }
                    // add the mText to the current space
                    var curSpace = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
                    MText mtext = new MText();
                    mtext.Location = startPoint;
                    mtext.Contents = text;
                    curSpace.AppendEntity(mtext);
                    tr.AddNewlyCreatedDBObject(mtext, true);
                    tr.Commit();
                }
                catch (Autodesk.AutoCAD.Runtime.Exception ex)
                {
                    ed.WriteMessage(("Exception: " + ex.Message));
                }
            }
        }
