        [Authorize]
        [HttpPost]
        public void BalanceStatement(BalanceStatementModel modelReceived)
        {
            
            List<FinanceEntity> rows = GetRunningBalanceDueForPractice();
           
            DataTable table = new DataTable();
            using (var reader = FastMember.ObjectReader.Create(rows, "ItemDescription", "EventDate", "Amount", "RunningBalanceDue"))
            {
                table.Load(reader);
            }
            ClosedXML.Excel.XLWorkbook workBook =  CommonBusinessMethodHelpers.GetWorkBook(table, "Statement");
            string formtFileName = "attachment;filename=\"BalanceStatement-{0}.xlsx\"";
            GenerateExcelInvoiceController(workBook, formtFileName);
            
        }
