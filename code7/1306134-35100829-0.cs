    public static class EditorExtension
    {
        public static void SetZAxisUcs (this Editor ed, Point3d basePoint, Point3d positiveZaxisPoint)
        {
            Plane plane = new Plane(basePoint, basePoint.GetVectorTo(positiveZaxisPoint));
            Matrix3d ucs = Matrix3d.PlaneToWorld(plane);
            ed.CurrentUserCoordinateSystem = ucs;
        }
    }
