        public ActionResult Edit(int id)
        {
            var series = _seriesService.Get(id);
            var model = Mapper.Map<Series, SeriesViewModel>(series); // here
            return View(model);
        }
