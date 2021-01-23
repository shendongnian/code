    var allfiles = Directory.GetFiles(imagesPath);
    this.imageList1.ImageSize = new Size(256, 250);
    this.imageList1.ColorDepth = ColorDepth.Depth32Bit;
    // Set the maximum value based on the number of files you get
    progressBar1.Invoke((MethodInvoker)(() => { progressBar1.Maximum = filesSorted.Count(); }));
    foreach (FileInfo fileInfo in filesSorted)
    {
        try
        {
            this.imageList1.Images.Add(fileInfo.Name,
            Image.FromFile(fileInfo.FullName));
        }
        catch
        {
            Console.WriteLine(fileInfo.FullName + "  is is not a valid image.");
        }
        // Update the ProgressBar, incrementing by 1 for each iteration of the loop
        progressBar1.Invoke((MethodInvoker)(() => progressBar1.Increment(1)));
    }
