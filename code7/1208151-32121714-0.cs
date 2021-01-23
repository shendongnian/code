    // Dump input images
    for (int i = 0; i < frames.Length; i++)
    {
        StorageFile file = await Windows.Storage.KnownFolders.PicturesLibrary.CreateFileAsync(
            string.Format("FRAME_{0}.yuv", i), CreationCollisionOption.ReplaceExisting);
                    
        byte[] image = SwapHeap.copyFromHeap(frames[i].ImagePtr, (int)frames[i].Width * (int)frames[i].Height * 3 / 2);
        await FileIO.WriteBytesAsync(file, image);
        image = null;
        file = null;
    }
