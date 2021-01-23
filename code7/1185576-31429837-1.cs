    [CommandMethod("XrefGraph")]
    public static void XrefGraph()
    {
      Document doc = Application.DocumentManager.MdiActiveDocument;
      Database db = doc.Database;
      Editor ed = doc.Editor;
      using (Transaction Tx = db.TransactionManager.StartTransaction())
      {
        ed.WriteMessage("\n---Resolving the XRefs------------------");
        db.ResolveXrefs(true, false);
        XrefGraph xg = db.GetHostDwgXrefGraph(true);
        ed.WriteMessage("\n---XRef's Graph-------------------------");
        ed.WriteMessage("\nCURRENT DRAWING");
        GraphNode root = xg.RootNode;
        printChildren(root, "|-------", ed, Tx);
        ed.WriteMessage("\n----------------------------------------\n");
      }
    }
     
    // Recursively prints out information about the XRef's hierarchy
    private static void printChildren(GraphNode i_root, string i_indent,
                                      Editor i_ed, Transaction i_Tx)
    {
      for (int o = 0; o < i_root.NumOut; o++)
      {
        XrefGraphNode child = i_root.Out(o) as XrefGraphNode;
        if (child.XrefStatus == XrefStatus.Resolved)
        {
          BlockTableRecord bl =
            i_Tx.GetObject(child.BlockTableRecordId, OpenMode.ForRead)
                as BlockTableRecord;
          i_ed.WriteMessage("\n" + i_indent + child.Database.Filename);
          // Name of the Xref (found name)
          // You can find the original path too:
          //if (bl.IsFromExternalReference == true)
          // i_ed.WriteMessage("\n" + i_indent + "Xref path name: "
          //                      + bl.PathName);
          printChildren(child, "| " + i_indent, i_ed, i_Tx);
        }
      }
    }
