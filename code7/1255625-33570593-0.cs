            BlockingCollection<string> collection = new BlockingCollection<string>();
            Action productionAction = () =>
            {
               //produce data then
                collection.Add(ProcessedData);
            };
            Action consumentAction = () =>
            {
               //consume data
                var data = collection.Take();
                //then
                //do your things
            };
            Parallel.Invoke(productionAction,consumentAction);
            // code will end here when everything will be processed
            // also you can change Action to TaskRun to use some Multithreading
