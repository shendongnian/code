            foreach (var item in items)
            {
                var closure = item;
                tasks.Add(
                    Task.Run(
                        () => GenerateXml(closure)));
            }
            Task.WaitAll(tasks.ToArray());
