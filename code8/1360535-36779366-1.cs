    class ThreeColumnListManager
    {
        public static async Task<ObservableCollection<ThreeColumnList>> GetList()
        {
            var threecolumnlists = new ObservableCollection<ThreeColumnList>();
    
            //Add a dummy row to present something on screen
            threecolumnlists.Add(new ThreeColumnList { Name = "Name1", Age = "Age1", Job = "Job1" });
    
            //First working method
            await readList(threecolumnlists);
    
            //Second Working Method
            //tryAgain(threecolumnlists);
    
            return threecolumnlists;
        }
    
        public static async Task readList(ObservableCollection<ThreeColumnList> tcl)
        {
            string _line;
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Lists/slplist.txt"));
            using (var inputStream = await file.OpenReadAsync())
            using (var classicStream = inputStream.AsStreamForRead())
            using (var streamReader = new StreamReader(classicStream))
            {
                while (streamReader.Peek() >= 0)
                {
                    Debug.WriteLine("Line");
                    _line = streamReader.ReadLine();
                    //Debug.WriteLine(string.Format("the line is {0}", _line ));
                    string _first = "" + _line.Split('-')[0];
                    string _second = "" + _line.Split('-')[1];
                    string _third = "" + _line.Split('-')[2];
    
                    tcl.Add(new ThreeColumnList { Name = _first, Age = _second, Job = _third });
                }
            }
        }
    
        public static async Task tryAgain(ObservableCollection<ThreeColumnList> tcl)
        {
            //Loading Folder
            var _folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            _folder = await _folder.GetFolderAsync("Lists");
    
            //Get the file
            var _file = await _folder.GetFileAsync("splist.txt");
    
            // read content
            IList<string> _ReadLines = await Windows.Storage.FileIO.ReadLinesAsync(_file);
    
            int i = 0;
            foreach (var _line in _ReadLines)
            {
                i++;
                string _first = "" + _line.Split('-')[0];
                string _second = "" + _line.Split('-')[1];
                string _third = "" + _line.Split('-')[2];
                tcl.Add(new ThreeColumnList { Name = _first, Age = _second, Job = _third });
            }
            Debug.WriteLine("Count is " + i);
        }
    }
