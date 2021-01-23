    public unsafe  Bitmap Retreive( byte [] values)
        {
            Bitmap bmp =new Bitmap(Width,Height);//enter your width and height here.
            BitmapData   bmData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width,bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
            IntPtr scan0 = bmData.Scan0;
            int stride = bmData.Stride;
            int nWidth = bmp.Width;
            int nHeight = bmp.Height;
               
               for(int y=0;y<nHeight;y++)
               {
                    //define the pointers inside the first loop for parallelizing
                    byte* p = (byte*)scan0.ToPointer();
                    p += y * stride;
                  
                    for (int x = 0; x < nWidth; x++)
                    {
                        
                        //fill as  the values stored in you byte array;
                        p[0]=values[0];// R component.
                        p[1]=values[1];// G component.
                         p[2]=values[2];// B component.
                         p[3]=values[3];// Alpha component.
                        p += 4;
                     
                    }
                }
                bmp.UnlockBits(bmData);
               
                return bmp;
            
        }
