        public static double[] GetDoubleInRangeNums()
        {
            List<double> list = new List<double>();
            double k = 0;
            list.Add(double.MinValue);
            list.Add(double.MaxValue);
            for (int i = 0; i < 3; i++)
            {
                k = randomizer.NextDouble(double.MaxValue);
                if (!list.Contains(k))
                {
                    list.Add(k);
                }
            }
            return list.ToArray();
        }
        [Test]
        [Category("DataType.Double")]
        public void DoubleInRangeTest([ValueSource("GetDoubleInRangeNums")]double value, [Values(1)]int flag)
        {
            string tableName = "DataTypeDouble";
            string columnType = "double precision";
            CreateTable(tableName, columnType);
            EsgynDbDataType_FloatPointNum(tableName, value, value, EsgynDBType.Double, flag);
        }
