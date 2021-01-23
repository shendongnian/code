    string defaultNamespace = "MyNamespace";
    string folderName = "XAML";
    string fileName = "Sample.xaml";
    
    string path = String.Format("{0}.{1}.{2}", defaultNamespace, folderName, fileName);
    
    using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(path))        
    {
        object root = XamlReader.Load(stream);
    }
