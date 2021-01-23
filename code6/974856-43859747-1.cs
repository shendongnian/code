            //This is the code for the DATASET shared
            static DataSet strDataset;
            //this is the catcher of DATASET info request...
            public static DataSet dtSet
            {
               get { return strDataset; }
               set { strDataset = value; }
            }
