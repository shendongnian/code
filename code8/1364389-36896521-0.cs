            var res = new List<Model.WorkItem>();
            Parallel.ForEach(allWorkItems, wi =>
            {
                var item = new Model.WorkItem();
                _mapper.MapCoreData(wi, item);
                _mapper.MapCustomData(wi, item);
                _mapper.MapLinks(wi, item);
                res.Add(item);
            });
            return res;
