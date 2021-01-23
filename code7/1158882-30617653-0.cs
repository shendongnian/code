        public bool Checkdb4oFile(string fileName)
        {
            try
            {
                using (IObjectContainer container = Db4oFactory.OpenFile(fileName))
                {
                    // do nothong;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
