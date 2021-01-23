                var tasks = new Task[2]
                {
                    Task.Factory.StartNew(() => {
                       //Process Data
                    }),
                    Task.Factory.StartNew(() => {
                        //Sleep while not sync.
                    })
                };
                Task.WaitAll(tasks);
