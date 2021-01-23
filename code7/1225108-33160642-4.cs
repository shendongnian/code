    Creating H5 file TestFile01.h5...
    H5 file TestFile01.h5 created successfully!
    Reading H5 file TestFile01.h5...
    chamberId=1 humid=100 temp=80
    chamberId=2 humid=101 temp=81
    chamberId=3 humid=102 temp=82
    chamberId=4 humid=103 temp=83
    chamberId=5 humid=104 temp=84
    Processing complete!
    public class SampleH5Modified
    {
        private string filename;
        private int count;
        const string dataSetName = "/SampleDataSet";
        public SampleH5Modified(string filename, int count)
        {
            this.filename = filename;
            this.count = count;
        }
        public void Run()
        {
            List<mData> data1 = new List<mData>();
            for (int i = 0; i < count; i++)
                data1.Add(new mData(i + 80, i + 100, i + 1));
            WriteData(data1);
            mData[] data2 = ReadData();
            foreach (mData d in data2)
                Console.WriteLine("chamberId={0} humid={1} temp={2}", d.chamberId, d.humid, d.temp);
            Console.WriteLine("Processing complete!");
        }
        private void WriteData(List<mData> data)
        {
            Console.WriteLine("Creating H5 file {0}...", filename);
            const int RANK = 1;
            long[] dims = new long[RANK];
            dims[0] = count;
            H5FileId fileId = H5F.create(filename, H5F.CreateMode.ACC_TRUNC);
            H5DataSpaceId spaceId = H5S.create_simple(RANK, dims);
            H5DataTypeId typeId = H5T.copy(H5T.H5Type.STD_REF_OBJ);
            int typeSize = H5T.getSize(typeId);
            H5DataSetId dataSetId = H5D.create(fileId, dataSetName, typeId, spaceId);
            H5D.write(dataSetId, new H5DataTypeId(H5T.H5Type.STD_REF_OBJ), new H5Array<mData>(data.ToArray()));
            H5D.close(dataSetId);
            H5F.close(fileId);
            Console.WriteLine("H5 file {0} created successfully!", filename);
        }
        private mData[] ReadData()
        {
            Console.WriteLine("Reading H5 file {0}...", filename);
            H5FileId fileId = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
            H5DataSetId dataSetId = H5D.open(fileId, dataSetName);
            mData[] readDataBack = new mData[count];
            H5D.read(dataSetId, new H5DataTypeId(H5T.H5Type.STD_REF_OBJ), new H5Array<mData>(readDataBack));
            H5D.close(dataSetId);
            H5F.close(fileId);
            return readDataBack;
        }
    }
