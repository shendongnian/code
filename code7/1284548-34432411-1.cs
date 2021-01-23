    public void RotateParticle(Graphics g, RectangleF r,
                                    RectangleF rShadow, float angle,
                                    Pen particleColor, Pen particleShadow)
    {
        PointF shadowPoint = new PointF(rShadow.Left + (rShadow.Width / 1),
                                        rShadow.Top + (rShadow.Height / 1));
        PointF particlePoint = new PointF(r.Left + (r.Width / 1),
                                          r.Top + (r.Height / 2));
        //Angle of the shadow gets set to the angle of the particle, 
        //that way we can rotate them at the same rate
        float shadowAngle = angle;
    
        //rotate and draw the shadow of the Particle
        g.RotateTransformAt(shadowAngle, shadowPoint);
        g.DrawRectangle(particleShadow, rShadow.X, rShadow.Y, rShadow.Width, rShadow.Height);
        g.ResetTransform();
    
        //Same stuff as before but for the actual particle
        g.RotateTransformAt(angle, particlePoint);
        g.DrawRectangle(particleColor, r.X, r.Y, r.Width, r.Height);
        g.ResetTransform();
    }
 
