    List<ToSend> sendToAPI = new List<ToSend>();
    List<label> labels = db.labels.ToList();
    foreach (var x in list) {
        var myLabels = labels.Where(q => !db.filter.Where(y => x.userid ==y.userid))
                             .Select(y => y.ID)
                             .Contains(q.id))
    
        //Render the HTML
        //do some fast stuff with objects
        sendToAPI.add(the object with HTML);
    }
    int maxParallelPOSTs=5;
    await TaskHelper.ForEachAsync(sendToAPI, maxParallelPOSTs, async i => {
        using (NasContext db2 = new NasContext()) {
            List<response> res = await api.sendMessage(i.object);  //POST
    
            //put all the responses in the db
            foreach (var r in res) 
            {
                db2.responses.add(r);
            }
        
            db2.SaveChanges();
        }
    });
        
        public static Task ForEachAsync<T>(this IEnumerable<T> source, int dop, Func<T, Task> body) {
            return Task.WhenAll(
                from partition in Partitioner.Create(source).GetPartitions(dop)
                select Task.Run(async delegate {
                    using (partition)
                        while (partition.MoveNext()) {
                            await body(partition.Current).ContinueWith(t => {
                                if (t.Exception != null) {
                                    string problem = t.Exception.ToString();
                                }
                                //observe exceptions
                            });
                        }
                }));
        }
