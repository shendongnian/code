    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    
    double i = 0;
    double size = zip.Count
    foreach(ZipEntry element in zip)
    {
        if(i % 500 == 0)
        {
            Console.Write("\rInstalling "+ name +"... "+ (i/size)*100 +"%");
            Console.Out.Flush();
        }
        element.Extract(destinationPath, ExtractExistingFileAction.OverwriteSilently);
        i++;
    }
    
    stopWatch.Stop();
    
    MessageBox.Show(stopWatch.ElapsedTicks.ToString()); //Or milliseconds ,...
