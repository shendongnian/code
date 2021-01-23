    using Autodesk.AutoCAD.Runtime;
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.EditorInput;
     
    namespace XrefApplication
    {
      public class Commands
      {
        [CommandMethod("DX")]
        static public void DetachXref()
        {
          Document doc =
            Application.DocumentManager.MdiActiveDocument;
          Database db = doc.Database;
          Editor ed = doc.Editor;
     
          // Select an external reference
     
          Transaction tr =
            db.TransactionManager.StartTransaction();
          using (tr)
          {
            BlockTableRecord btr = null;
            ObjectId xrefId = ObjectId.Null;
     
            // We'll loop, as we need to open the block and
            // underlying definition to check the block is
            // an external reference during selection
     
            do
            {
              PromptEntityOptions peo =
                new PromptEntityOptions(
                  "\nSelect an external reference:"
                );
              peo.SetRejectMessage("\nMust be a block reference.");
              peo.AddAllowedClass(typeof(BlockReference), true);
     
              PromptEntityResult per = ed.GetEntity(peo);
              if (per.Status != PromptStatus.OK)
                return;
     
              // Open the block reference
     
              BlockReference br =
                (BlockReference)tr.GetObject(
                  per.ObjectId,
                  OpenMode.ForRead
                );
     
              // And the underlying block table record
     
              btr =
                (BlockTableRecord)tr.GetObject(
                  br.BlockTableRecord,
                  OpenMode.ForRead
                );
     
              // If it's an xref, store its ObjectId
     
              if (btr.IsFromExternalReference)
              {
                xrefId = br.BlockTableRecord;
              }
              else
              {
                // Otherwise print a message and loop
     
                ed.WriteMessage(
                  "\nMust be an external reference."
                );
              }
            }
            while (!btr.IsFromExternalReference);
     
            // If we have a valid ObjectID for the xref, detach it
     
            if (xrefId != ObjectId.Null)
            {
              db.DetachXref(xrefId);
              ed.WriteMessage("\nExternal reference detached.");
            }
     
            // We commit the transaction simply for performance
            // reasons, as the detach is independent
     
            tr.Commit();
          }
        }
      }
    }
