    using (var tr = db.TransactionManager.StartTransaction())
    {
        // the newly created MText have to be disposed after using
        using (MText mt = new MText())
        {
            mt.Contents = text;
             // check if the MLeaderStyle dictionary does not already contains a style named "MyLeaderStyle"
            DBDictionary mlStyles = (DBDictionary)tr.GetObject(db.MLeaderStyleDictionaryId, OpenMode.ForWrite);
            if (!mlStyles.Contains("MyLeaderStyle"))
            {
                // create a new instance of MLeaderStyle (you can use the overloaded ctor to copy an existing style)
                MLeaderStyle dst = new MLeaderStyle();
                dst.ArrowSymbolId = ObjectId.Null;
                dst.ArrowSize = 0.18 * scale;
                dst.ContentType = 0;
                dst.DefaultMText = mt;
                dst.LandingGap = gap;
                dst.EnableBlockRotation = true;
                dst.MaxLeaderSegmentsPoints = 2;
                // add the new MLeaderStyle to the database
                dst.PostMLeaderStyleToDb(db, "MyLeaderStyle");
                tr.AddNewlyCreatedDBObject(dst, true);
            }
        }
        tr.Commit();
    }
