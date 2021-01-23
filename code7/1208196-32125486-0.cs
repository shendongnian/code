	using (Transaction tr = db.TransactionManager.StartTransaction())
    {
        DBDictionary layoutDic
            = tr.GetObject(
                            db.LayoutDictionaryId,
                            OpenMode.ForRead,
                            false
                          ) as DBDictionary;
 
        foreach (DBDictionaryEntry entry in layoutDic)
        {
            ObjectId layoutId = entry.Value;
 
            Layout layout
                = tr.GetObject(
                                layoutId,
                                OpenMode.ForRead
                              ) as Layout;
 
            ed.WriteMessage(
                String.Format(
                                "{0}--> {1}",
                                Environment.NewLine,
                                layout.LayoutName
                             )
                           );
        }
        tr.Commit();
    }
