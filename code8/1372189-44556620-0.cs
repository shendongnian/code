    Matrix WorldViewMatrix;
    public Vector3 Position;
    
        public void Render( SharpDX.Direct3D11.Buffer constantBuffer, SharpDX.Direct3D11.Device device, Matrix viewProj )
        {
        WorldViewMatrix =  Matrix.Scaling(Scale) * Matrix.RotationX(Rotation.X) * Matrix.RotationY(Rotation.Y) * Matrix.RotationZ(Rotation.Z) * Matrix.Translation(Position.X, Position.Y, Position.Z) * viewProj;
        WorldViewMatrix.Transpose();
        device.ImmediateContext.UpdateSubresource(ref WorldViewMatrix, constantBuffer);
        //device.ImmediateContext.PixelShader.SetShaderResource(0, textureView);
        device.ImmediateContext.Draw(VerticesCount,0);
        }
