    type
      TOutlookFolderItemsEvent = procedure(ASender: TObject; const Item: IDispatch) of object;
      TOutlookFolderItems = class(TOleServer)
      private
        FIntf: _Items;
        FOnItemAdd: TOutlookFolderItemsEvent;
      protected
        procedure InitServerData; override;
        procedure InvokeEvent(DispID: TDispID; var Params: TVariantArray); override;
      public
        procedure Disconnect; override;
        procedure Connect; override;
        procedure ConnectTo(svrIntf: _Items);
    
        property OnItemAdd: TOutlookFolderItemsEvent read FOnItemAdd write FOnItemAdd;
      end;
    
      TMyForm = class(TForm)
        OutlookApplication1: TOutlookApplication;
      private
        FMyEntryID: String;
        FItems: TOutlookFolderItems;
        procedure ItemsItemAdd(ASender: TObject; const Item: IDispatch);
        procedure MySendEmail;
      end;
    
    procedure TMyForm.MySendEmail;
    var
      Mi: MailItem;
      EntryID: TGUID;
    begin
      OutlookApplication1.Disconnect;
      OutlookApplication1.Connect;
      OutlookApplication1.Application.ActiveExplorer.WindowState := olMaximized;
    
      CreateGuid(EntryID);
      FMyEntryID:= GUIDToString(EntryID);
      Mi.UserProperties.Add('MyEntryID', olText, True, olText).Value := FMyEntryID;
    
      Mi.Save;
      Mi.Display(0);
    
      // Add the following code to OutlookApplication's OnItemSend
      // to get a more accurate SaveSentMessageFolder
      // (as it may change when selecting from different From accounts)
      FItems := TOutlookFolderItems.Create(Self);
      FItems.ConnectTo(Mi.SaveSentMessageFolder.Items);
      FItems.OnItemAdd := ItemsItemAdd;
    end;
    
    procedure TMyForm.ItemsItemAdd(ASender: TObject; const Item: IDispatch);
    var
      S: String;
      I: MailItem;
      P: UserProperty;
    begin
      I := Item as MailItem;
    
      P := I.UserProperties.Find('MyEntryID', True);
    
      if (P = nil) or (P.Value <> FMyEntryID) then Exit; // Not the email we're waiting for
    
      // MailItem is known to be sent and in SentFolders here.
      // Add here any relevant code.
    end;
    
    { TOutlookFolderItems }
    
    procedure TOutlookFolderItems.Connect;
    begin
    end;
    
    procedure TOutlookFolderItems.ConnectTo(svrIntf: _Items);
    begin
      Disconnect;
      FIntf := svrIntf;
      ConnectEvents(FIntf);
    end;
    
    procedure TOutlookFolderItems.Disconnect;
    begin
      if Fintf <> nil then
      begin
        DisconnectEvents(FIntf);
        FIntf := nil;
      end;
    end;
    
    procedure TOutlookFolderItems.InitServerData;
    const
      CServerData: TServerData = (
        ClassID:   '{00063052-0000-0000-C000-000000000046}';
        IntfIID:   '{00063041-0000-0000-C000-000000000046}';
        EventIID:  '{00063077-0000-0000-C000-000000000046}';
        LicenseKey: nil;
        Version: 500);
    begin
      ServerData := @CServerData;
    end;
    
    procedure TOutlookFolderItems.InvokeEvent(DispID: TDispID; var Params: TVariantArray);
    begin
      case DispID of
        -1: Exit;  // DISPID_UNKNOWN
        61441: if Assigned(FOnItemAdd) then
             FOnItemAdd(Self, Params[0] {const IDispatch});
      end;
    end;
