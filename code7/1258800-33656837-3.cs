               if (comboBox1.Text == "Lock")
               {
                   Cursor.Current = Cursors.WaitCursor;
                   Thread.Sleep(1000);
                   oItem.Frozen = BoYesNoEnum.tYES;
                   Cursor.Current = Cursors.Default;
               }
               else if (comboBox1.Text == "Unlock")
               {
                   Cursor.Current = Cursors.WaitCursor;
                   Thread.Sleep(1000);
                   oItem.Frozen = BoYesNoEnum.tNO;
                   Cursor.Current = Cursors.Default;
               }
