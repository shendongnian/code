        class SettingsViewModel
        {
            PictureRecognitionIntensivity intensity;
            public string Intensivity 
            { 
                get
                {
                    return intensity.ToString(); 
                } 
                
                set
                { 
                    intensity = (PictureRecognitionIntensivity)Enum.Parse(typeof(PictureRecognitionIntensivity), value); 
                } 
            }
            public string[] PictureRecognitionIntensivityValues
            {
                get {
                    List<string> values = new List<string>();
                    Array iValues = PictureRecognitionIntensivity.GetValues(typeof(PictureRecognitionIntensivity));
                    foreach(int value in iValues)
                        values.Add(((PictureRecognitionIntensivity)value).ToString());
                    return values.ToArray();
                
                }
            }
            public SettingsViewModel()
            {
                // Set default values for testing;
                this.intensity = PictureRecognitionIntensivity.Moderate;
            }
        }
