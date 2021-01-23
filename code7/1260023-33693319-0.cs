    procedure TForm1.Button1Click(Sender: TObject);
    var
      Client: TMsRdpClientNotSafeForScripting;
    begin
      Client:= TMsRdpClientNotSafeForScripting.Create(Self);
      Client.Parent:= Form1;
      Client.Server:= Edit1.Text;
      Client.ControlInterface.UserName:= Edit2.Text;
      Client.AdvancedSettings2.ClearTextPassword:= Edit3.Text;
      Client.Connect;
    end;
