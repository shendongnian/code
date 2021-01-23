    [CommandMethod("FindGroup")]
    static public void FindGroup()
    {
      Document doc =
          Application.DocumentManager.MdiActiveDocument;
      Database db = doc.Database;
      Editor ed = doc.Editor;
      PromptEntityResult acSSPrompt =
          ed.GetEntity("Select the entity to find the group");
    
      if (acSSPrompt.Status != PromptStatus.OK)
        return;
    
      using (Transaction Tx =
          db.TransactionManager.StartTransaction())
      {
        Entity ent = Tx.GetObject(acSSPrompt.ObjectId,
                                OpenMode.ForRead) as Entity;
        ObjectIdCollection ids = ent.GetPersistentReactorIds();
    
        bool bPartOfGroup = false;
        foreach (ObjectId id in ids)
        {
          DBObject obj = Tx.GetObject(id, OpenMode.ForRead);
    
          if (obj is Group)
          {
            Group group = obj as Group;
            bPartOfGroup = true;
            ed.WriteMessage(
                "Entity is part of " + group.Name + " group\n");
    
          }
        }
    
        if (!bPartOfGroup)
          ed.WriteMessage(
                  "Entity is Not part of any group\n");
        Tx.Commit();
      }
    }
