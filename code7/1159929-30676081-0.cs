    private void AddSearchToDropDown ()
       {
          Task.Factory.StartNew (() =>
          {
             if (CanAdd && filterTxtBox.Text.Length > 2)
             {
                CanAdd = false;
                Thread.Sleep (4000);
                this.Invoke(new Action(() =>
                {
                   filterTxtBox.AutoCompleteMode = AutoCompleteMode.None;
                   m_suggestedTests.Add (filterTxtBox.Text);
                   filterTxtBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                   CanAdd = true;
                 }));
             }
          });
       }
