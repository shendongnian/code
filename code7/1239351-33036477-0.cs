            try
            {
               
                string StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                string datalogicFilePath = Path.Combine(StartupPath, "Database\\SFAHabib.sdf");
                mConnStr = string.Format("DataSource={0}", datalogicFilePath);
                msqlConnection = new SqlCeConnection(mConnStr); 
            }
            catch (Exception ex)
            {
               
            }
        }
