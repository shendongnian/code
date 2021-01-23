        public MainWindow()
        {
            InitializeComponent();
            SceneView sv = new SceneView();
            FileElevationSource elv = new FileElevationSource();
            elv.Filenames.Add(@"C:\Maps\NJ\elev\n40_w075_1arc_v3.tif");
            sv.Scene.ElevationSourceLoaded += (object sender, ElevationSourceLoadedEventArgs e) =>
            {
                elevtest(elv);
            };
            sv.Scene.Surface.Add(elv);
            Content = sv;
            sv.Visibility = System.Windows.Visibility.Hidden;
        }
        async void elevtest(FileElevationSource elv)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            double nSamples = 1000.0;
            double delta = 1 / nSamples;
            for (double i = 0; i < 1.0; i += delta)
            {
                double elev = await elv.GetElevationAsync(new Esri.ArcGISRuntime.Geometry.MapPoint(-75 + i, 40 + i, SpatialReferences.Wgs84));
            }
            sw.Stop();
            System.Diagnostics.Trace.WriteLine(sw.ElapsedMilliseconds / nSamples + " ms per sample" );
        }
