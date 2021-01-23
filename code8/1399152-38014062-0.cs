     public class PersistantStorageHelper<T>
        {
            IMvxFileStoreAsync _mvxFileStoreAsync;
            IMvxFileStore _mvxFileStore;
            EDEngine bcEngine = new EDEngine(new AesEngine(), Encoding.UTF8);
            string currentkey_temp_dev = "AthulHarikumar00";//This static key is not being used it is a just a place holder
          
            public PersistantStorageHelper() {
                this._mvxFileStore = Mvx.Resolve<IMvxFileStore>();
                this._mvxFileStoreAsync = Mvx.Resolve<IMvxFileStoreAsync>();
                bcEngine.SetPadding(new Pkcs7Padding());
                currentkey_temp_dev = Constants.PassPhrase.Substring(4, 12)+"Road";
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public async Task<T> GetPersistantObject(T obj)
            {
                var fileName = (typeof(T).ToString().Replace(".", "_"));
               var x= await GetPersistantObject(obj, fileName);
                return x;
            }
            /// <summary>
            /// If object exists returns the object else saves a plain object and returns it
            /// </summary>
            /// <param name="obj">empty placeholder object</param>
            /// <returns>Filesystem object</returns>
            public async Task<T> GetPersistantObject( T obj,string fileName) {
    
                List<string> files = new List<string>(_mvxFileStore.GetFilesIn(_mvxFileStore.NativePath("")));
                fileName = _mvxFileStore.NativePath(fileName);
    
                if (!files.Contains(fileName))
                {
                    var objJson = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                
                    objJson= bcEngine.Encrypt(objJson, currentkey_temp_dev);
                    await _mvxFileStoreAsync.WriteFileAsync(fileName,objJson);
                }
                else {
                    try
                    {
                      
                        var temp = await _mvxFileStoreAsync.TryReadTextFileAsync(fileName);
                        var str = bcEngine.Decrypt(temp.Result, currentkey_temp_dev);
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
                    }
                    catch(Exception e) {
                        var objJson = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
    
                        objJson = bcEngine.Encrypt(objJson, currentkey_temp_dev);
                        await _mvxFileStoreAsync.WriteFileAsync(fileName, objJson);
                    }
                }
    
                return obj;
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public async Task<T> SetPersistantObject(T obj)
            {
                var fileName = _mvxFileStore.NativePath(typeof(T).ToString().Replace(".", "_"));
                var temp = await SetPersistantObject(obj, fileName);
                return temp;
    
            }
            /// <summary>
            /// Saves object to persistant storage with encryption
            /// </summary>
            /// <param name="obj">object to be stored</param>
            /// <returns>Saved object</returns>
            public async Task<T> SetPersistantObject(T obj,string fileName)
            {
    
                List<string> files = new List<string>(_mvxFileStore.GetFilesIn(_mvxFileStore.NativePath("")));
                 fileName = _mvxFileStore.NativePath(fileName);
    
              
                    var objJson = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                objJson = bcEngine.Encrypt(objJson, currentkey_temp_dev);
                await _mvxFileStoreAsync.WriteFileAsync(fileName, objJson);
                
                
    
                return obj;
            }
        }
