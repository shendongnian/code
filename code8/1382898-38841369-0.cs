    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Sheets.v4;
    using Google.Apis.Sheets.v4.Data;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace GoogleSheetsAPI4_v1console
    {
        class Program
        {
            // If modifying these scopes, delete your previously saved credentials
            // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
            static string[] Scopes = { SheetsService.Scope.Spreadsheets}; // static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
            static string ApplicationName = "<MYSpreadsheet>";
    
            static void Main(string[] args)
            {
                UserCredential credential;
    
                using (var stream =
                    new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
    
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
    
                // Create Google Sheets API service.
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
    
    
    
                String spreadsheetId2 = "<my spreadsheet ID>";
                String range2 = "<my page name>!F5";  // update cell F5 
                ValueRange valueRange = new ValueRange();
                valueRange.MajorDimension = "COLUMNS";//"ROWS";//COLUMNS
    
                var oblist = new List<object>() { "My Cell Text" };
                valueRange.Values = new List<IList<object>> { oblist };
    
                SpreadsheetsResource.ValuesResource.UpdateRequest update = service.Spreadsheets.Values.Update(valueRange, spreadsheetId2, range2);
                update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                UpdateValuesResponse result2 = update.Execute();
    
                Console.WriteLine("done!");
    
            }
        }
    }
