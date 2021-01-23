    var map = new[] {
        new TreemapItem("ItemA", 0, Brushes.DarkGray) {
            Children = new[] {
                new TreemapItem("ItemA-1", 200, Brushes.White),
                new TreemapItem("ItemA-2", 500, Brushes.BurlyWood),
                new TreemapItem("ItemA-3", 600, Brushes.Purple),
            }
         },
        new TreemapItem("ItemB", 1000, Brushes.Yellow) {
        },
        new TreemapItem("ItemC", 0, Brushes.Red) {
            Children = new[] {
                new TreemapItem("ItemC-1", 200, Brushes.White),
                new TreemapItem("ItemC-2", 500, Brushes.BurlyWood),
                new TreemapItem("ItemC-3", 600, Brushes.Purple),
            }
        },
        new TreemapItem("ItemD", 2400, Brushes.Blue) {
        },
        new TreemapItem("ItemE", 0, Brushes.Cyan) {
            Children = new[] {
                new TreemapItem("ItemE-1", 200, Brushes.White),
                new TreemapItem("ItemE-2", 500, Brushes.BurlyWood),
                new TreemapItem("ItemE-3", 600, Brushes.Purple),
            }
        },
    };
    using (var bmp = new Treemap().Build(map, 1024, 1024)) {
        bmp.Save("output.bmp", ImageFormat.Bmp);
    }
