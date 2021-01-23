        public TValue Revive<TValue>(string path, params object[] constructorArgs)
        {
            try
            {
                using (var stream = File.OpenRead(path))
                {
                    //var currentCulture = Thread.CurrentThread.CurrentCulture;
                    //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                    try
                    {
                        var serializer = new DataContractJsonSerializer(type, Settings);
                        var item = (TValue) serializer.ReadObject(stream);
                        if (Equals(item, null)) throw new Exception();
                        return item;
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.ToString());
                        return (TValue) Activator.CreateInstance(type, constructorArgs);
                    }
                    finally
                    {
                        //Thread.CurrentThread.CurrentCulture = currentCulture;
                    }
                }
            }
            catch
            {
                return (TValue) Activator.CreateInstance(typeof (TValue), constructorArgs);
            }
        }
