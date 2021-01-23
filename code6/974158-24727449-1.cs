    using (frmObjStyles thisForm = new frmObjStyles())
    {
         thisForm.ShowDialog();
         if (thisForm.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
              //curItem2 = thisForm.tabCntrlObjStyle.SelectedTab.ToString();
              curItem2 = thisForm.ThePropertyYouCreated;
              //curItem = thisForm.lstBoxStruc.SelectedItem.ToString();
              curItem = thisForm.TheOtherPropertyYouCreated;
              MessageBox.Show("This is your Selected Value: " +
              Environment.NewLine + curItem +
                            Environment.NewLine + curItem2,
                            "Your Data", MessageBoxButtons.OK);
              // Create a Collection of Values a user can Select
              //List<string> structList = new List<string>(structInput);
              //it would probably be better to place this next here...
              //return Result.Succeeded;
         }
         else
         {
              return Result.Cancelled;
         }
    
    
    }
