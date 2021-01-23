        Dictionary<ModelVisual3D, StlDataObject> modelDataMap = new Dictionary<ModelVisual3D, StlDataObject>();
        public void LoadModelWithData(string dataFilePath, string stlModelPath)
        {
            ModelImporter tr = new ModelImporter();
            var model = tr.Load("C:\\Users\\...\\Pictures\\a.stl");
            ModelVisual3D test = new ModelVisual3D();
            test.Content = model;
            //Load the datafile from file (or pass it this method)
            StlDataObject IdForOurStlModel = GetStlDataFromFile(dataFilePath);
            modelDataMap.Add(test, IdForOurStlModel);
        }
