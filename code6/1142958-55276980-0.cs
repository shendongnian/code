    public class PDFResult : ActionResult
    {
        private readonly byte[] fileContents;
        private string fileName;
    
        public PDFResult(byte[] contents, string filename)
        {
            this.fileContents = contents;
            this.fileName = filename;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.Clear();
            response.ContentType = "application/pdf";
            response.AddHeader("content-disposition", string.Format(@"attachment;filename=""{0}""", fileName));
            response.BinaryWrite(fileContents);
        }
    }
