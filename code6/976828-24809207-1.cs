    public class ViewModel
    {
        public string Code { get; set; }
        public string Label{ get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
    var entity = new myEntity { 
        Code = viewModel.Code,
        Label = viewModel.Label,
        DateStart = viewModel.DateStart
        ... dont know what you want to do with DateEnd
    }
