    private Outlook.AppointmentItem _item;
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
       this.Application.ItemLoad += 
          new Outlook.ApplicationEvents_11_ItemLoadEventHandler(Application_ItemLoad);
    }
    private void Application_ItemLoad(object item)
    {
       if (item is Outlook.AppointmentItem)
       {
          this._item = item as Outlook.AppointmentItem;
          this._item.Read += _item_Read;
        }
    }
    private void _item_read()
    {
       // Example access of Recipients property
       var recipients = this._item.Recipients;
    }
