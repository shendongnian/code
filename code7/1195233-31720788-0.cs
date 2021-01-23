    Quad tempQuad = new Quad() 
    {
        Texture = QuadTexture,
        Vertices = new VertexPositionTexture[]
                    {
                        new VertexPositionTexture 
                        {
                            Position = new Vector3(0, 100, 0),
                            Color = Color.Red
                        }, 
                        // ... define other vertices here
                    }
    };
