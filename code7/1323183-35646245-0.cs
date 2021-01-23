        public PartialViewResult Ticker(int param) {
            TickerModel model = new TickerModel();
            // TODO: fill the model 
            return PartialView(model);
        }
