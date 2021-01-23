        {
            var client = new HttpClient();
            var uri = new Uri("http://www.blabla.com/alliance/App/mobilelogin.php?KG=MA&EM="+Textboxname.Text+"&PA="+password.Password);
            var response = await client.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            RootObject TotalList = new RootObject();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
            RootObject resu = (RootObject)ser.ReadObject(ms);
           NavigationContext nav = new NavigationContext()
            {
                ID = resu.USERID.ToString(),
                Name = resu.NAME.ToString(),
                Email = resu.EMAIL.ToString()
          }
       
            SaveFile();
            RestoreFile(); 
             }
        private async void SaveFile()
        {
            StorageFile userdetailsfile = await ApplicationData.Current.LocalFolder.CreateFileAsync("UserDetails", CreationCollisionOption.ReplaceExisting);
            IRandomAccessStream raStream = await userdetailsfile.OpenAsync(FileAccessMode.ReadWrite);
            using (IOutputStream outStream = raStream.GetOutputStreamAt(0))
            {
                // Serialize the Session State.
                DataContractSerializer serializer = new DataContractSerializer(typeof(NavigationContext));
                serializer.WriteObject(outStream.AsStreamForWrite(), nav);
                await outStream.FlushAsync();
            }  
        }
        private async void RestoreFile()
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("UserDetails");
           if (file == null) return;
           IRandomAccessStream inStream = await file.OpenReadAsync();
            // Deserialize the Session State.
            DataContractSerializer serializer = new DataContractSerializer(typeof(NavigationContext));
            var StatsDetails = (NavigationContext)serializer.ReadObject(inStream.AsStreamForRead());
            inStream.Dispose();   
            string hu = StatsDetails.Name + "\n" + StatsDetails.Email;
            //  UserName.Text = "Welcome " + StatsDetails.Name;
            // UserProfileId = StatsDetails.Id;
            resultblock.Text = hu; 
           
        }
   }
    public class RootObject
    {
        public string USERID { get; set; }
        public string EMAIL { get; set; }
        public string NAME { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string CITY { get; set; }   
    }
    public class NavigationContext
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
