            BasicEffect basicEffect = new BasicEffect(device);
            basicEffect.Texture = myTexture;
            basicEffect.TextureEnabled = true;
    
            VertexPositionTexture[] vert = new VertexPositionTexture[4];
            vert[0].Position = new Vector3(0, 0, 0);
            vert[1].Position = new Vector3(100, 0, 0);
            vert[2].Position = new Vector3(0, 100, 0);
            vert[3].Position = new Vector3(100, 100, 0);
    
            vert[0].TextureCoordinate = new Vector2(0, 0);
            vert[1].TextureCoordinate = new Vector2(1, 0);
            vert[2].TextureCoordinate = new Vector2(0, 1);
            vert[3].TextureCoordinate = new Vector2(1, 1);
    
            short[] ind = new short[6];
            ind[0] = 0;
            ind[1] = 2;
            ind[2] = 1;
            ind[3] = 1;
            ind[4] = 2;
            ind[5] = 3;
