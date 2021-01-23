    [TestClass()]
    public class ExcelUpdateLogicTests {
        [TestMethod()]
        public void Given_SheetName_ExcelDocument_Should_GetWorkseetPart() {
            //Arrange
            var stream = new MemoryStream();//Avoid having to use actual file on disk
            var spreadsheetDocument = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);
            // Add a WorkbookPart.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            // Add a WorksheetPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            // Add a sheets list.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
            // Append the new worksheet and associate it with the workbook.
            string expectedId = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart);
            string sheetName = "mySheet";
            Sheet sheet = new Sheet() {
                Id = expectedId,
                SheetId = 1,
                Name = sheetName
            };
            sheets.Append(sheet);
            var wrapper = new SpreadsheetDocumentWrapper(spreadsheetDocument);
            string fakeFilePath = "path";
            var sut = new ExcelDocument(fakeFilePath);
            //Act
            WorksheetPart result = sut.GetWorksheetPart(wrapper, sheetName);
            //Assert
            Assert.IsNotNull(result);
            var actualId = spreadsheetDocument.WorkbookPart.GetIdOfPart(result);
            Assert.AreEqual(expectedId, actualId);
        }
    }
