    Matrix proj = Matrix.Identity;
        RenderLoop.Run(form, () =>{
                var viewProj = Matrix.Multiply(myMesh.ViewLayer.Camera.getView(), proj);
                //...
                    if (IHandler.KeyRight) { myMesh.Position.X += 0.050f; }
                    if (IHandler.KeyLeft)  { myMesh.Position.X -= 0.050f; }
                    if (IHandler.KeyUp)    { myMesh.Position.Z += 0.050f; }
                    if (IHandler.KeyDown)  { myMesh.Position.Z -= 0.050f; }
                    if (IHandler.KeyQ)     { myMesh.Position.Y -= 0.050f; }
                    if (IHandler.KeyE)     { myMesh.Position.Y += 0.050f; }
                //...
                myMesh.Render(contantBuffer, device, viewProj);
        });
