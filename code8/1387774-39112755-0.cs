            var reqs = new BatchUpdateSpreadsheetRequest();
            reqs.Requests = new List<Request>();
			string[] colNames = new [] { "timestamp", "videoid", "videoname", "firstname", "lastname", "email" };
			// Create starting coordinate where data would be written to
			GridCoordinate gc = new GridCoordinate();
			gc.ColumnIndex = 0;
			gc.RowIndex = 0;
			gc.SheetId = SHEETID; // Your specific sheet ID here
			rq = new Request();
			rq.UpdateCells = new UpdateCellsRequest();
			rq.UpdateCells.Start = gc;
			rq.UpdateCells.Fields = "*"; // needed by API, throws error if null
			// Assigning data to cells
			RowData rd = new RowData();
			List<CellData> lcd = new List<CellData>();
			foreach (String column in colNames)
			{
				ExtendedValue ev = new ExtendedValue();
				ev.StringValue = column;
				CellData cd = new CellData();
				cd.UserEnteredValue = ev;
				lcd.Add(cd);
			}
			rd.Values = lcd;
			// Put cell data into a row
			List<RowData> lrd = new List<RowData>();
			lrd.Add(rd);
			rq.UpdateCells.Rows = lrd;
            // It's a batch request so you can create more than one request and send them all in one batch. Just use reqs.Requests.Add() to add additional requests for the same spreadsheet
			reqs.Requests.Add(rq);
            // Execute request
            response = sheetsService.Spreadsheets.BatchUpdate(reqs, Spreadsheet.SpreadsheetId).Execute(); // Replace Spreadsheet.SpreadsheetId with your recently created spreadsheet ID
