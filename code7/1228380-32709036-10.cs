    public async Task<List<myClass>> GetLoadTimeTakenAsync(List<myClass> myClassList)
            {
                Parallel.ForEach(myClassList, myClassObj =>
                {
                    using (var client = new HttpClient())
                    {
                        myClassObj.StartTime = DateTime.Now;
                        var stream = client.GetStreamAsync(myClassObj.URL)
                                            .ContinueWith((s) =>
                                            {
                                                if (s.IsCompleted)
                                                {
                                                    var myClassObjCompleted = myClassList.Where(x => x.URL == myClassObj.URL).First();
                                                    myClassObjCompleted.EndTime = DateTime.Now;
                                                    myClassObjCompleted.TimeTaken = myClassObj.EndTime - myClassObj.StartTime;
                                                }
                                            });
                        Task.Run(async () => await stream);
                    }
                });
    
                while (myClassList.Any(x => x.TimeTaken == null))
                {
                    await Task.Delay(1);
                }
    
                return myClassList;
            }
