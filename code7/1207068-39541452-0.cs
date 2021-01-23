    static void Draw(Mesh m)
    {
        m.CalculateMatrices(MainCamera);
        FrustumCulling.ExtractFrustum(MainCamera.GetViewMatrix() * MainCamera.GetProjectionMatrix());
        float Scale = Math.Max(m.Scale.X, Math.Max(m.Scale.Y, m.Scale.Z));
    
        if (FrustumCulling.SphereInFrustum(m.Position, m.BoundingSphere.Outer * Scale))
            for (int i = 0; i < m.Parts.Count; i++)
                // ...
                    Draw(m, m.Parts[i]);
    }
