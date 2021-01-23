    object[,] result = new object[10, 5];
    for(int i = 0; i < 10; i++) {
        result[i, 0] = (double)i;
        result[i, 1] = "test";
        result[i, 2] = (double)i;
        result[i, 3] = "test";
        result[i, 4] = (double)i;
    }
    List<object> list = new List<object>();
    for(int i = 0; i < result.GetLength(0); i++) {
        list.Add(new { Field1 = result[i, 0], Field2 = result[i, 1], Field3 = result[i, 2], Field4 = result[i, 3], Field5 = result[i, 4] });
    }
    gridControl1.DataSource = list;
