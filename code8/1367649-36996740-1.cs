      <DataGridTemplateColumn.CellEditingTemplate>
                            <DataTemplate>
                                <ComboBox Height="20" IsEditable="True"
                                          ItemsSource="{Binding StatusList}"
                                          SelectedItem="{Binding Status}"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellEditingTemplate>
       List<TicketInfo> ticketsList = new List<TicketInfo> 
                {
                    new TicketInfo{ Subject="Show Ping", Status="True",StatusList=new List<string>(){"True","False"}},
                    new TicketInfo{ Subject="Show Drawings", Status="True",StatusList=new List<string>(){"True","False"}},
                    new TicketInfo{ Subject="Send Debug Messages", Status="True",StatusList=new List<string>(){"True","False"}},
                    new TicketInfo{ Subject="Enable Default Profile", Status="False",StatusList=new List<string>(){"True","False"}}
                };
 
    public class TicketInfo
        {
            public string Subject { get; set; }
    
            private string _status;
            public string Status
            {
                get { return _status; }
                set { _status = value; }
            }
            private List<string> _statusList = new List<string>();
            public List<string> StatusList
            {
                get { return _statusList; }
                set { _statusList = value; }
            }
        }
