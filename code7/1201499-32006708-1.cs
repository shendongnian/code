    private void textBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
          if (e.DataObject.GetDataPresent(typeof(String)))
          {
            var text = (String)e.DataObject.GetData(typeof(String));
            if (!isTextAllowed(text))
            {
              e.CancelCommand();
            }
          }
          else
          {
            e.CancelCommand();
          }
        }
