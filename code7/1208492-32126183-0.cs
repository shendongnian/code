    static void WriteArrayByRows()
    {
        H5FileId h5 = H5F.create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.h5"), H5F.CreateMode.ACC_TRUNC);
        H5DataSpaceId dsi = H5S.create_simple(2, new long[] { ROWS, COLS });
        H5DataSetId dataset = H5D.create(h5, "array", new H5DataTypeId(H5T.H5Type.NATIVE_USHORT), dsi);
        ushort[,] array = new ushort[ROWS, COLS];
        ushort value = 1;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = value++;
            }
        }
        for (int i = 0; i < array.GetLength(0); i++)
        {
            H5S.selectHyperslab(dsi, H5S.SelectOperator.SET, new long[] { i, 0 }, new long[] { 1, array.GetLength(1) });
            H5DataSpaceId dsi2 = H5S.create_simple(2, new long[] { 1, array.GetLength(1) });  // added
            ushort[,] row = new ushort[1, array.GetLength(1)];
            for (int j = 0; j < array.GetLength(1); j++)
            {
                row[0, j] = array[i, j];
            }
            H5PropertyListId pli = new H5PropertyListId(H5P.Template.DEFAULT);  // added
            H5D.write<ushort>(dataset, new H5DataTypeId(H5T.H5Type.NATIVE_USHORT), dsi2, dsi, pli, new H5Array<ushort>(row));  // modified
        }
        H5D.close(dataset);
        H5F.close(h5);
    }
