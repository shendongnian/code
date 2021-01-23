    // new class with a single string
	public class InputData {
		public string fileString { get; set; }
	}
    
    // new controller 
    [HttpPost]
    public IHttpActionResult UploadExcel([FromBody]InputTitle myInput) {
        string fileString = myInput.fileString;
        // cut
    }
