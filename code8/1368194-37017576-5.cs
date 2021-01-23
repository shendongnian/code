                public static void DrawSphere(T Radius, Int32 Slices, Int32 Stacks, 
                GLU.QuadricDrawStyles Style, GLU.QuadricNormals Normal, Color color)
            {
                OpenGL.SetColor(color);
                GLU.GLUquadric quadric = new GLU.GLUquadric();
                quadric.Init((int)Normal, (int)Style, 0, false);
                GLU.Sphere(ref quadric, (dynamic)Radius, Slices, Stacks);
            }
