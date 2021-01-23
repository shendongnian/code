    private void Playlist_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;  
    }
    
    private void Playlist_DragDrop(object sender, DragEventArgs e)
    {
        //get the file names
        string[] songs = (string[])e.Data.GetData(DataFormats.FileDrop, false);
    
        //we're using a Parallel.ForEach loop because if a directory is selected it can contain n number of items, this is to help prevent a bottleneck.
        Parallel.ForEach(songs, song =>
        {
            //make sure the file exists
            if (File.Exists(song))
            {
                //if it's an mp3 file then call AddFileToListview
                if (string.Compare(Path.GetExtension(song), ".mp3", true) == 0)
                {
                    AddFileToListview(song);
                }
            }
            //A HA! It's a directory not a single file
            else if (Directory.Exists(song))
            {
                //get the directory information
                DirectoryInfo di = new DirectoryInfo(song);
    
                //get all the mp3 files (will add WMA in the future)
                FileInfo[] files = di.GetFiles("*.mp3");
    
                //here we use a parallel loop to loop through every mp3 in the
                //directory provided
                Parallel.ForEach(files, file =>
                {
                    AddFileToListview(file.FullName);
                });
            }
        });
    }
            
    private void AddFileToListview(string fullFilePath)
    {
        double nanoseconds;
        string totalTime = string.Empty;
    
        //First things first, does the file even exist, if not then exit
        if (!File.Exists(fullFilePath))
            return;
    
        //get the song name
        string song = Path.GetFileName(fullFilePath);
    
        //get the directory
        string directory = Path.GetDirectoryName(fullFilePath);
    
        //hack off the trailing \
        if (directory.EndsWith(Convert.ToString(Path.DirectorySeparatorChar)))
            directory = directory.Substring(0, directory.Length - 1); 
    
        //now we use the WindowsAPICodePack.Shell to start calculating the songs time
        ShellFile shell = ShellFile.FromFilePath(fullFilePath);
                
        //get the length is nanoseconds
        double.TryParse(shell.Properties.System.Media.Duration.Value.ToString(), out nanoseconds);
                
        //first make sure we have a value greater than zero
        if (nanoseconds > 0)
        {
            // double milliseconds = nanoseconds * 0.000001;
            TimeSpan time = TimeSpan.FromSeconds(Utilities.ConvertToMilliseconds(nanoseconds) / 1000);
            totalTime = time.ToString(@"m\:ss");
        }
    
        //build oour song data
        ListViewItem item = new ListViewItem();
        item.Text = song;
        item.SubItems.Add(totalTime);
    
        //now my first run at this gave me a cross-thread exception when trying to add multiple single mp3's
        //but I could add all the whole directories I wanted, o that is why we are now using BeginINvoke to access the ListView
        if (Playlist.InvokeRequired)
            Playlist.BeginInvoke(new MethodInvoker(() => Playlist.Items.Add(item)));
        else
            Playlist.Items.Add(item);            
    }
