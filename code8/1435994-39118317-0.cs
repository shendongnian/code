                IList<Object> obj = new List<Object>();
                obj.Add("A2");
                obj.Add("B2");
                IList<IList<Object>> values = new List<IList<Object>>();
                values.Add(obj);
    
                SpreadsheetsResource.ValuesResource.AppendRequest request =
                        service.Spreadsheets.Values.Append(new ValueRange() { Values = values }, spreadsheetId, range);
                request.InsertDataOption = SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum.INSERTROWS;
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;
                var response = request.Execute();
