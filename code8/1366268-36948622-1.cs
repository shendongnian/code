    public unsafe void editSoftwarebitmap(SoftwareBitmap softwareBitmap)
    {
        //create buffer
        using (BitmapBuffer buffer = softwareBitmap.LockBuffer(BitmapBufferAccessMode.Write))
        {
            using (var reference = buffer.CreateReference())
            {
                byte* dataInBytes;
                uint capacity;
                ((IMemoryBufferByteAccess)reference).GetBuffer(out dataInBytes, out capacity);
                //fill-in the BGRA plane
                BitmapPlaneDescription bufferLayout = buffer.GetPlaneDescription(0);
                for (int i = 0; i < bufferLayout.Height; i++)
                {
                    for (int j = 0; j < bufferLayout.Width; j++)
                    {
                        //get offset of the current pixel
                        var pixelStart = bufferLayout.StartIndex + bufferLayout.Stride * i + 4 * j;
                        //get gradient value to set for blue green and red
                        byte value = (byte)((float)j / bufferLayout.Width * 255);
                        dataInBytes[pixelStart + 0] = value; //Blue
                        dataInBytes[pixelStart + 1] = value; //Green
                        dataInBytes[pixelStart + 2] = value; //Red
                        dataInBytes[pixelStart + 3] = (byte)255; //Alpha
                    }
                }
            }
        }
    }
