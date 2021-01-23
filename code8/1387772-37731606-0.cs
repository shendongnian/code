                ValueRange VRx = new ValueRange();
                IList<IList<object>> xx = new List<IList<object>>();
                xx.Add(new List<object> { "test" });
                VRx.Values = xx;
                SpreadsheetsResource.ValuesResource.UpdateRequest update = service.Spreadsheets.Values.Update(VRx, spreadsheetId, "back!A19");
                //update.ValueInputOption.Value = { USER_ENTERED };
                UpdateValuesResponse result = update.Execute(); 
