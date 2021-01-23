    procedure TForm1.ChangeColumn(Sender: TcxCustomGridTableView; isConnected: boolean);
    var i: integer; AColumn: TcxCustomGridTableItem;
    begin
      if ((TcxGridDBTableView(Sender).Controller.SelectedRecordCount=0)
        or (TcxGridDBTableView(Sender).Controller.SelectedRecords[0] = nil))
      then exit;
    
      AColumn:= TcxGridDBTableView(Sender).GetColumnByFieldName('Discontinued');
      if AColumn = nil then exit;
    
      TcxGridDBTableView(Sender).DataController.BeginFullUpdate;
      try
      	for i:= 0 to TcxGridDBTableView(Sender).Controller.SelectedRecordCount-1 do
      	begin
      		TcxGridDBTableView(Sender).Controller.SelectedRecords[i].Values[AColumn.index] := isConnected;
      	end;
    
      finally
        TcxCustomGridTableView(Sender).DataController.EndFullUpdate;
      end;
    end;
