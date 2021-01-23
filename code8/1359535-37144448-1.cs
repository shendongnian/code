      /// <summary>
      /// Determines if the command can be executed based on TicketViewModel properties.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      public void CanExecuteCustomCommand(object sender,
          CanExecuteRoutedEventArgs e)
      {
         // NOTE: This may need more complex handling such as in ExecutedCustomCommand.
         //       Right now, it is dependent on specific control names, which is not optimal.
         // This is usually always PTTicketView, not the originating control.
         Control target = e.Source as Control;
         // This is the control that actually executes the command.
         Control orig = e.OriginalSource as Control;
         
         if (orig == null)
         {
            e.CanExecute = false;
         }
         else
         {
            string ctlName = orig.Name;
            if (dataContext == null)
            {
               e.CanExecute = true;
            }
            else
            {
               if (dataContext.SelectedTab != TicketViewModel.Tabs.MultiLeg)
               {
                  e.CanExecute = true;
               }
               else
               {
                  if (controlsBuy.Contains(ctlName))
                  {
                     e.CanExecute = dataContext.IsCommandBuyEnabled;
                  }
                  else if (controlsSell.Contains(ctlName))
                  {
                     e.CanExecute = dataContext.IsCommandSellEnabled;
                  }
                  else if (controlsOther.Contains(ctlName))
                  {
                     e.CanExecute = dataContext.IsCommandOtherEnabled;
                  }
                  else if (controlsExpiries.Contains(ctlName))
                  {
                     e.CanExecute = (dataContext.IsExpiriesEnabled && dataContext.IsIndicative);
                  }
                  else if (ctlName.Equals("DealableTypeToggle"))
                  {
                     e.CanExecute = dataContext.IsRFSEnabled;
                  }
                  else
                  {
                     e.CanExecute = true;
                  }
               }
            }
         }
      }
