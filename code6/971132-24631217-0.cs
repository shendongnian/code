                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                    
                    GL.Begin(PrimitiveType.Lines);
                    GL.Color3(Color.White);
                    //YAxis
                    GL.Vertex2(0.0f, 2.0f);
                    GL.Vertex2(0.0f, -2.0f);
                    
                    //X-Axis
                    GL.Vertex2(2.0f, 0.0f);
                    GL.Vertex2(-2.0f, 0.0f);
                    GL.End();
                    GL.Begin(PrimitiveType.Points);
		    // Plotting the Graph
                    GL.Color3(Color.DeepSkyBlue);
                    for(float i=0;i<2.0;i=(float) (i+0.001))
                    {
                        GL.Vertex2(i,i);
                    }
                    GL.End();
                    game.SwapBuffers();
                };
