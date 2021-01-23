    var groupedItems = myDataList
                    .GroupBy(q =>
                        new
                        {
                            q.Col1,
                            q.Col2,
                            q.Col3,
                            q.Col4,
                            q.Col5  // notice this
                        }).ToList();
