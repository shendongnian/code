    using HelixToolkit.Wpf;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;
    namespace Axcro.Helix_Toolkit_Extentions
       {
       class RectGrid : GridLinesVisual3D
    {
        private Vector3D lengthDirection;
        private Vector3D widthDirection;
        private void AddLineY(MeshBuilder mesh, double y, double minX,     double maxX, double thickness)
        {
            int i0 = mesh.Positions.Count;
            mesh.Positions.Add(this.GetPoint(minX, y + thickness / 2));
            mesh.Positions.Add(this.GetPoint(maxX, y + thickness / 2));
            mesh.Positions.Add(this.GetPoint(maxX, y - thickness / 2));
            mesh.Positions.Add(this.GetPoint(minX, y - thickness / 2));
            mesh.Normals.Add(this.Normal);
            mesh.Normals.Add(this.Normal);
            mesh.Normals.Add(this.Normal);
            mesh.Normals.Add(this.Normal);
            mesh.TriangleIndices.Add(i0);
            mesh.TriangleIndices.Add(i0 + 1);
            mesh.TriangleIndices.Add(i0 + 2);
            mesh.TriangleIndices.Add(i0 + 2);
            mesh.TriangleIndices.Add(i0 + 3);
            mesh.TriangleIndices.Add(i0);
        }
            private Point3D GetPoint(double x, double y)
        {
            return this.Center + this.widthDirection * x +     this.lengthDirection * y;
        }
            private static bool IsMultipleOf(double y, double d)
        {
            double y2 = d * (int)(y / d);
            return (y - y2) < 1e-3;
            }
            protected override MeshGeometry3D Tessellate()
            {
                this.lengthDirection = this.LengthDirection;
                this.lengthDirection.Normalize();
                this.widthDirection = Vector3D.CrossProduct(this.Normal,     this.lengthDirection);
                this.widthDirection.Normalize();
                var mesh = new MeshBuilder(true, false);
                double minX = -this.Width / 2;
                double minY = -this.Length / 2;
                double maxX = this.Width / 2;
                double maxY = this.Length / 2;
                double eps = this.MinorDistance / 10;
                double y = minY;
                while (y <= maxY + eps)
                {
                    double t = this.Thickness;
                    if (IsMultipleOf(y, this.MajorDistance))
                    {
                        t *= 2;
                    }
                    this.AddLineY(mesh, y, minX, maxX, t);
                    y += this.MinorDistance;
                }
                var m = mesh.ToMesh();
                m.Freeze();
                return m;
            }
        }
    }
