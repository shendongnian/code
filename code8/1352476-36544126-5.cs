    Document doc =Application.DocumentManager.MdiActiveDocument ;
    Database db =doc.Database ;
    Editor ed =doc.Editor ;
    
    PromptSelectionResult psr =ed.GetSelection () ;
    SelectionSet ss =psr.Value ;
    SelectedObject so =ss [0] ;
    
    Transaction tr =doc.TransactionManager.StartTransaction () ;
    Entity ent =tr.GetObject (so.ObjectId, OpenMode.ForWrite) as Entity ;
    ObjectId layerId =ent.Layer ;
    // ... do something with ent ...
    // Eventually set a new layer
    ent.Layer =newLayer ;
    
    tr.Commit () ;
    // Regen clears highlighting and reflects the new layer
    ed.Regen () ;
