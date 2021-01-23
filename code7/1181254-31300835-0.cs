    [Route("api/plotlist")]
    [HttpGet]
    public PlotListModel GetPlotList() {
        //Here's where you would instantiate and populate your model
        PlotListModel plotList; 
        
        /*
         * Once your model is instantiated and populated then you can
         * just return it and the serialization will be done for you
         */
       
        return plotList;
    }
