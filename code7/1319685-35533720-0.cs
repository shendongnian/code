            ObjectId mlStyleId;
            
            DBDictionary mlStyles = (DBDictionary)acTrans.GetObject(acCurDb.MLeaderStyleDictionaryId, OpenMode.ForRead);
            if (mlStyles.Contains("MyLeaderStyle"))
            {
                mlStyleId = mlStyles.GetAt("MyLeaderStyle");
            }
            else
            {
                MLeaderStyle dst = new MLeaderStyle();
                dst.ArrowSymbolId = ObjectId.Null;
                dst.ArrowSize = 0.5 * scale;
                dst.LandingGap = 0;
                dst.EnableBlockRotation = true;
                dst.MaxLeaderSegmentsPoints = 2;
                dst.EnableLanding = true;
                mlStyleId = dst.PostMLeaderStyleToDb(acCurDb, "MyLeaderStyle");
                acTrans.AddNewlyCreatedDBObject(dst, true);
            }
            MLeader lead = new MLeader();
            int i = lead.AddLeader();
            lead.AddLeaderLine(i);
            lead.AddFirstVertex(i, new Point3d(pickPont[0], pickPont[1], 0));
            lead.AddLastVertex(i, new Point3d(pickPont[0] + 5, pickPont[1] + 5, 0));
            lead.MLeaderStyle = mlStyleId;
            acBlkTblRec.AppendEntity(lead);
            acTrans.AddNewlyCreatedDBObject(lead, true);
            acTrans.Commit();
