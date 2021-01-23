          List<Point3D> points = new List<Point3D>();
          Parallel.ForEach(workspace.PointCloud, point =>
          {
            //Do Work
          }
          );
          Point3DCollection p3d = new Point3DCollection(points);
          mymesh.Positions = p3d;
