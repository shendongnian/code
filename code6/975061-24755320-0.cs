    foreach (Control ctrl in this.Controls)
    {
         if (ctrl.GetType() == typeof(ComboBox))
         {
            clsMasterFunc.TableName = ctrl.Text;
            dsMasterList = clsMasterFunc.select();
            ((ComboBox)ctrl).DataSource = dsMasterList.Tables[0];
         }
    }
