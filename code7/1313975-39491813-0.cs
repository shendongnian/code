    using System;
    using System.Collections.Generic;
    using System.IO;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using Google.Apis.Sheets.v4;
    using Google.Apis.Sheets.v4.Data;
    
    namespace SheetApiTest
    {
        public class SheetApiWithGoogleCredentials
        {
            static string[] Scopes = { SheetsService.Scope.Spreadsheets };
            static string ApplicationName = "Google Sheets API .NET Quickstart";
    
            public void AppendData()
            {
                // the downloaded jsonn file with private key
                var credential = GoogleCredential.FromStream(new FileStream("Sheets-test.json", FileMode.Open)).CreateScoped(Scopes);
            
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                // spreadsheet id - your own spreadsheet id
                var spreadsheetId = "11AwV7d1pEPq4x-rx9WeZHNwGJa0ehfRhh760";
            
                var valueRange = new ValueRange { Values = new List<IList<object>> { new List<object>() } };
                valueRange.Values[0].Add(DateTime.Now.ToLongTimeString());
            
                // insert here the name of your spreadsheet table
                var rangeToWrite = "Tabellenblatt1";
                var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, rangeToWrite);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var appendReponse = appendRequest.Execute();
            }
        }
    }
