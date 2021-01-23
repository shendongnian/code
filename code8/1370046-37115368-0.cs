    internal class ButtonResources
    {
        #region Static Fields
        private static ResourceManager resourceManager = 
            new ResourceManager("MyApplication.Resources.ButtonResources",
                                typeof(ButtonResources).Assembly);
        private static Dictionary<String,ButtonResources> resourceDictionary =
            new Dictionary<String, ButtonResources>();
        #endregion
        #region Instance Properties
        internal String Text { get; set; }
        internal BitmapImage Image { get; set; }
        internal SolidColorBrush Brush { get; set; }
        #endregion
        #region Instance Fields
        private String Name { get; set; }
        #endregion
        private ButtonResources(String buttonName)
        {
            this.Name = buttonName;
        }
        private void LoadResources(CultureInfo culture)
        {
            // Load the button Text 
            Text = resourceManager.GetString(Name + "Text", culture);
            // Load the image file from a URI.
            // See https://msdn.microsoft.com/en-us/library/aa970069(v=vs.100).aspx
            // (It's regrettably complex, but there are lots of examples on t'interweb.)
            String imageName = resourceManager.GetString(Name + "Image", culture);
            Image = new BitmapImage(new Uri(@"pack://application:,,,/"
                + Assembly.GetExecutingAssembly().GetName().Name
                + ";component/Resources/"
                + imageName, UriKind.Absolute));
            // Convert the colour resource to a suitable Brush object.
            String colourName = resourceManager.GetString(Name + "Colour", culture);
            Brush = new BrushConverter().ConvertFromString(colourName) as SolidColorBrush;
        }
        internal static ButtonResources FindButton(String buttonName, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(buttonName))
            {
                throw new ArgumentException("The name of the button cannot be Null or Empty",
                                            "buttonName");
            }
            ButtonResources buttonResources;
            // Check whether the requested resource has been loaded yet.
            if (resourceDictionary.ContainsKey(buttonName))
            {
                buttonResources = resourceDictionary[buttonName];
            }
            else
            {
                // Create a new instance with the requested name.
                buttonResources = new ButtonResources(buttonName);
                // Load the object's properties from the Resources.
                buttonResources.LoadResources(culture);
                // Add the new object to the dictionary.
                resourceDictionary.Add(buttonName, buttonResources);
            }
            return buttonResources;
        }
    }
