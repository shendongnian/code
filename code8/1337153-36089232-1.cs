        public IAsyncEnumerable<ResultItem> EnumerateItemsWithReadAhead(enumType itemType)
        {
            return new AsyncEnumerable<ResultItem>(async yield => {
                Task<Response> nextBatchTask = FetchNextBatch(itemType);
                Boolean keepGoing = true;
                while (keepGoing) {
                    var response = await nextBatchTask;
                    // Kick off the next batch request (read ahead)
                    keepGoing = response.moreRecordsExist;
                    if (keepGoing)
                        nextBatchTask = FetchNextBatch(itemType);
                    foreach (ResultItem cr in response.ResultList)
                        await yield.ReturnAsync(cr);
                }
            });
        }
        private Task<Response> FetchNextBatch(enumType itemType)
        {
            // 100 records max per call
            var w = new WebServiceClient();
            request.enumType = itemType;
            // MUST BE ASYNC
            return w.responseAsync();
        }
