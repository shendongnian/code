    [CommandMethod("MYORBIT")]
    public void MyOrbit()
    {
      Document doc = Application.DocumentManager.MdiActiveDocument;
      Database db = doc.Database;
      Editor ed = doc.Editor;
      PromptPointResult ppr = ed.GetPoint("\nSelect orbit point: ");
      if (ppr.Status == PromptStatus.Cancel) return;
      using (Transaction tr = db.TransactionManager.StartTransaction())
      {
        short cvport = (short)Application.GetSystemVariable("CVPORT");
        using (Manager gm = doc.GraphicsManager)
        using (var kd = new KernelDescriptor())
        {
          kd.addRequirement(Autodesk.AutoCAD.UniqueString.Intern("3D Drawing"));
          using (View view = gm.ObtainAcGsView(cvport, kd))
          {
            double d = view.Position.DistanceTo(view.Target);
            view.SetView(ppr.Value + new Vector3d(-1, -1, 1).GetNormal() * d, ppr.Value, Vector3d.ZAxis, view.FieldWidth, view.FieldHeight);
            gm.SetViewportFromView(cvport, view, true, true, true);
          }
        }
        // Needed if wireframe 2D
        ed.Regen();
        tr.Commit();
      }
    }
