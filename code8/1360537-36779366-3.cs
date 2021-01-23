    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using Windows.Foundation.Collections;
    using Windows.Storage;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    namespace TestUWP
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            private ObservableCollection<ThreeColumnList> threeColumnLists;
    
            public ObservableCollection<ThreeColumnList> ThreeColumnLists
            {
                get { return threeColumnLists ?? (threeColumnLists = new ObservableCollection<ThreeColumnList>()); }
                set { threeColumnLists = value; }
            }
            public MainPage()
            {
                this.InitializeComponent();
                LoadData();
    
            }
    
            private async void LoadData()
            {
                //you can also change the private threeColumnLists to a static 
                // and do 
                //if(ThreeColumnLists.Count==0) 
                //   ThreeColumnLists = await ThreeColumnListManager.GetListAsync();
                ThreeColumnLists = await ThreeColumnListManager.GetListAsync();
                //can also do
                // await ThreeColumnListManager.readList(ThreeColumnLists);
            }
          
        }
    
        public class ThreeColumnList : INotifyPropertyChanged
        {
            private string name = string.Empty;
            public string Name { get { return name; } set { name = value; NotifyPropertyChanged("Name"); } }
    
            private string age = string.Empty;
            public string Age { get { return age; } set { age = value; NotifyPropertyChanged("Age"); } }
    
            private string job = string.Empty;
            public string Job { get { return job; } set { job = value; NotifyPropertyChanged("Job"); } }
    
            //PropertyChanged handers
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }
        }
        public class ThreeColumnListManager
        {
            public static async Task<ObservableCollection<ThreeColumnList>> GetListAsync()
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
    }
