            int x = r.X;
            int y = r.Y;
            int width = r.Width;
            int height = r.Height;
            int newY = 0; 
            for (y = r.Y; y < height+r.Y; y++) //For each line in the old image
            {
                byte* p = (byte*)scan0.ToPointer();
                p += y * stride;
                byte* p2 = (byte*)scan02.ToPointer();
                p2 += newY * stride2;
                for (x=r.X; x < width+r.X; x++)
                {
                    p2[0] = p[0];
                    p2[1] = p[1];
                    p2[2] = p[2];
                    p2[3] = p[3];
                    p += 4;
                    p2 += 4;
                }
                newY++;
            }
            result.Save("\\a.png");
