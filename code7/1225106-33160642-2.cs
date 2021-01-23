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
        public void Main()
        {
            WriteData();
            ReadData();
            Console.WriteLine("Processing complete!");
        }
        private void WriteData()
        {
            Console.WriteLine("Creating H5 file {0}...", filename);
            // Rank is the number of dimensions of the data array.
            const int RANK = 1;
            // Create an HDF5 file.
            // The enumeration type H5F.CreateMode provides only the legal 
            // creation modes.  Missing H5Fcreate parameters are provided
            // with default values.
            H5FileId fileId = H5F.create(filename,
                                         H5F.CreateMode.ACC_TRUNC);
            // Prepare to create a data space for writing a 1-dimensional 
            // signed integer array.
            long[] dims = new long[RANK];
            dims[0] = count;
            // Put descending ramp data in an array so that we can
            // write it to the file.
            mData[] dset_data = new mData[count];
            for (int i = 0; i < count; i++)
            {
                dset_data[i] = new mData(i + 80, i + 40, i + 1);
            }
            // Create a data space to accommodate our 1-dimensional array.
            // The resulting H5DataSpaceId will be used to create the 
            // data set.
            H5DataSpaceId spaceId = H5S.create_simple(RANK, dims);
            // Create a copy of a standard data type.  We will use the 
            // resulting H5DataTypeId to create the data set.  We could
            // have  used the HST.H5Type data directly in the call to 
            // H5D.create, but this demonstrates the use of H5T.copy 
            // and the use of a H5DataTypeId in H5D.create.
            H5DataTypeId typeId = H5T.copy(H5T.H5Type.STD_REF_OBJ);
            // Find the size of the type
            int typeSize = H5T.getSize(typeId);
            // Create the data set.
            H5DataSetId dataSetId = H5D.create(fileId, dataSetName,
                                               typeId, spaceId);
            // Write the integer data to the data set.
            H5D.write(dataSetId, new H5DataTypeId(H5T.H5Type.STD_REF_OBJ),
                              new H5Array<mData>(dset_data));
            H5D.close(dataSetId);
            H5F.close(fileId);
            Console.WriteLine("H5 file {0} created successfully!", filename);
        }
        private void ReadData()
        {
            Console.WriteLine("Reading H5 file {0}...", filename);
            H5FileId fileId = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
            H5DataSetId dataSetId = H5D.open(fileId, dataSetName);
            // Create an integer array to receive the read data.
            mData[] readDataBack = new mData[count];
            // Read the integer data back from the data set
            H5D.read(dataSetId, new H5DataTypeId(H5T.H5Type.STD_REF_OBJ),
                new H5Array<mData>(readDataBack));
            Console.WriteLine("File contents:");
            // Echo the data
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("chamberId={0} humid={1} temp={2}", readDataBack[i].chamberId, readDataBack[i].humid, readDataBack[i].temp);
            }
            // Close all the open resources.
            H5D.close(dataSetId);
            H5F.close(fileId);
        }
    }
