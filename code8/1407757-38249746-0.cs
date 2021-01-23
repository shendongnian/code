    class GizmoManager
    {
      void RunThisMethod(Action a)
      {
        // To draw the Gizmo at some point
        a();
      }
      // You can also pass other parameters before or after the lambda
      void RunThisMethod(Action a, TimeSpan duration)
      {
        // ...
      }
    }
    
    // Make the drawing actions lambdas
    GizmoManager.RunThisMethod(() => Gizmos.DrawSphere(Vector3.zero, 1f));
    GizmoManager.RunThisMethod(() => Gizmos.DrawWireMesh(myMesh));
    // You could also draw multiple if needed:
    GizmoManager.RunThisMethod(() => {
        Gizmos.DrawSphere(Vector3.zero, 1f);
        Gizmos.DrawWireMesh(myMesh);
    });
