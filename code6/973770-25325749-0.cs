     private async void Application_Launching(object sender, LaunchingEventArgs e) 
            { 
                try 
                { 
                    await ApplicationData.Current.LocalFolder.GetFileAsync("UniversityDB.db"); 
                    Connection = new SQLiteAsyncConnection("UniversityDB.db"); 
                } 
                catch (FileNotFoundException) 
                { 
                    DataService.CreateDbAsync(); 
                } 
            }
