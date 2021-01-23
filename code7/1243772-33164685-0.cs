 		static void ReadGribTwoFile()
        {
            #region Grib 2 Code
            Grib2Input input = new Grib2Input(RandomAccessFile);
            if (!input.scan(false, false))
            {
                Console.WriteLine("Failed to successfully scan grib file");
                return;
            }
            Grib2Data data = new Grib2Data(RandomAccessFile);
            var records = input.Records;
            foreach (Grib2Record record in records)
            {
                IGrib2IndicatorSection iis = record.Is;
                IGrib2IdentificationSection id = record.ID;
                IGrib2ProductDefinitionSection pdsv = record.PDS;
                IGrib2GridDefinitionSection gdsv = record.GDS;
                long time = id.RefTime.AddTicks(record.PDS.ForecastTime * 3600000).Ticks;
                Console.WriteLine("Record description at " + " forecast " + new DateTime(time) + ": " + string.Format("{0} {1} {2}", iis.Discipline, pdsv.ParameterCategory, pdsv.ParameterNumber));
                float[] values = data.getData(record.getGdsOffset(), record.getPdsOffset());
                if ((iis.Discipline == 0) && (pdsv.ParameterCategory == 1) && (pdsv.ParameterNumber == 1))
                {
                    // RH
                    int c = 0;
                    for (double lat = gdsv.La1; lat >= gdsv.La2; lat = lat - gdsv.Dy)
                    {
                        for (double lon = gdsv.Lo1; lon <= gdsv.Lo2; lon = lon + gdsv.Dx)
                        {
                            Console.WriteLine("RH " + lat + "\t" + lon + "\t" + values[c]);
                            c++;
                        }
                    }
                }
            }
            #endregion
        }
