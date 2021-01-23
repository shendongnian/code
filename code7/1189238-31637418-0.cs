     public static string GetLocalFilePath(string filename)
            {
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string dbPath = Path.Combine(path, filename);
    
                CopyDatabaseIfNotExists(dbPath);
    
                return dbPath;
            }
    
            private static void CopyDatabaseIfNotExists(string dbPath)
            {
                if (!File.Exists(dbPath))
                {
                    using (var br = new BinaryReader(Application.Context.Assets.Open("KDLife_mobileDB.db3")))
                    {
                        using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                        {
                            byte[] buffer = new byte[2048];
                            int length = 0;
                            while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                bw.Write(buffer, 0, length);
                            }
                        }
                    }
                }
            }
    
    		protected override void OnCreate (Bundle bundle)
    		{
    			base.OnCreate (bundle);
    
    			global::Xamarin.Forms.Forms.Init (this, bundle);
                global::Xamarin.FormsMaps.Init(this, bundle);
    
                string dbPath = GetLocalFilePath("KDLife_mobileDB.db3");
    
    			LoadApplication (new KDLife_mobile.App ());
    
                App.ScreenWidth = (int)Resources.DisplayMetrics.WidthPixels;
                App.ScreenHeight = (int)Resources.DisplayMetrics.HeightPixels;
    
                
    		}
