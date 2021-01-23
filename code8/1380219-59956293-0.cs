lang-cs
public class SpreadsheetRow
{
    public string Category { get; set; }
    public int Frequency { get; set; }
}
Then use **ExcelToEnumerable** to convert the spreadsheet data into an `IEnumerable` of type `SpreadsheetRow`
lang-cs
var filePath = "../Path/To/Spreadsheet.xlsx";
IEnumerable<SpreadsheetRow> result = filePath.ExcelToEnumerable<SpreadsheetRow>(x => x.UsingHeaderNames(false)
    .Property(y => y.Category).UsesColumnNumber(0)
    .Property(y => y.Frequency).UsesColumnNumber(1));
*Disclaimer*: I'm the author of ExcelToEnumerable
