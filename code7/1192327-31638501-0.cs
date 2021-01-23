        public override void Highlight(bool toggle)
        {
            if(toggle)
            {
                rect.Texture = new Texture2D(GraphicsManager.Graphics.GraphicsDevice, 1, 1);
                rect.Texture.SetData<Color>(new Color[] { Color.Yellow });
            }
            else
            {
                rect.Texture = new Texture2D(GraphicsManager.Graphics.GraphicsDevice, 1, 1);
                rect.Texture.SetData<Color>(new Color[] { squareColor });
            }
        }
