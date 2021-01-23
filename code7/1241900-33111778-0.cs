        public class Dto
        {
            public DateTime PeriodStart { get; set; }
            public DateTime PeriodEnd { get; set; }
            public string AgentNumber { get; set; }
            public string ExcelFileBase64 { get; set; }
            public string PdfFileBase64 { get; set; }
            public string CarrierCode { get; set; }
        }
        [HttpPost]
        public bool UploadAgentStatement(Dto dto)
        {
            var excelFile = Convert.FromBase64String(dto.ExcelFileBase64);
            var pdfFile = Convert.FromBase64String(dto.PdfFileBase64);
            var success = _apiUnitOfWork.UploadStatement(dto.PeriodStart, dto.PeriodEnd, dto.AgentNumber, excelFile, pdfFile, dto.CarrierCode);
            return success;
        }
