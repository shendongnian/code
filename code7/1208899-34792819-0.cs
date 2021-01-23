    private void UpdateTransforms()
        {
            if (!this.IsAttachedToViewport3D())
            {
                return;
            }
            Matrix3D view, projection;
            if (Camera.GetCameraMatrixes(out view, out projection))
            {
                Vector3D up = new Vector3D(view.M12, view.M22, view.M32);
                Vector3D look = new Vector3D(view.M13, view.M23, view.M33);
                Transform3D transform = Transform;
                Matrix3D inverseWorld = this.GetTransform();
                inverseWorld.Invert();
                look = inverseWorld.Transform(look);
                look.Normalize();
                up = inverseWorld.Transform(up);
                up.Normalize();
                Quaternion q = LookAtRotation(look, up);
                Transform3DGroup grp = new Transform3DGroup();
                grp.Children.Add(new RotateTransform3D(new QuaternionRotation3D(q), CenterPosition));
                grp.Children.Add(transform);
                Transform = grp;
                Camera.Refresh();
            }
        }
        private static Quaternion LookAtRotation(Vector3D lookAt, Vector3D upDirection)
        {
            Vector3D forward = lookAt;
            Vector3D up = upDirection;
            // Orthonormalize
            forward.Normalize();
            up -= forward * Vector3D.DotProduct(up, forward);
            up.Normalize();
            Vector3D right = Vector3D.CrossProduct(up, forward);
            Quaternion q = new Quaternion
            {
                W = Math.Sqrt(1.0 + right.X + up.Y + forward.Z) * 0.5
            };
            double w4Recip = 1.0 / (4.0 * q.W);
            q.X = (up.Z - forward.Y) * w4Recip;
            q.Y = (forward.X - right.Z) * w4Recip;
            q.Z = (right.Y - up.X) * w4Recip;
            return q;
        }
