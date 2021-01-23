        public object PopulateJumpList(string directoryName)
        {
            try
            {
                string programLocation = Assembly.GetCallingAssembly().Location;
                var di = new DirectoryInfo(directoryName);
                var jt = new JumpTask
                {
                    ApplicationPath = programLocation,
                    Arguments = directoryName,
                    Description = "Run at " + directoryName,
                    IconResourcePath = programLocation,
                    Title = di.Name
                };
                JumpList.AddToRecentCategory(jt);
                return jt;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
