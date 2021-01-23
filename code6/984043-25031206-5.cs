    var vm = new ViewModel();
    vm.ShapeItems = new ObservableCollection<ShapeItem>();
    vm.ShapeItems.Add(
        new ShapeItem
        {
            Geometry = new EllipseGeometry(new Point(100, 100), 100, 50),
            Fill = Brushes.LightBlue
        });
    vm.ShapeItems.Add(
        new ShapeItem
        {
            Geometry = new RectangleGeometry(new Rect(150, 100, 200, 100)),
            Fill = Brushes.Azure,
            Stroke = Brushes.Black
        });
    DataContext = vm;
