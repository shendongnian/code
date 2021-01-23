       public MainWindow()
        {
            InitializeComponent();
            PopulateNextTenYears();
        }
     
       
        private void PopulateNextTenYears()
        {
            //Check to see whether the year_combo is empty.
            //If yes, then simply add years from today to next 10 years
            if(year_combo.Items.Count==0)
            {
              for(int i=0;i<10;i++)
              {
                  ComboBoxItem itemCombo = new ComboBoxItem()
                  {
                      Content=""+(DateTime.Now.Year+i)
                  };
                 
                  if(i==9)
                  {
                      //If the combobox item is last, then register it to RequestBringIntoView event handler
                      itemCombo.RequestBringIntoView += itemCombo_RequestBringIntoView;
                  }
                  //Add the combobox item to year_combo
                  year_combo.Items.Add(itemCombo);
              }
            }
                //If year_combo has some items i.e it is not empty, then extract the last year from combobox
                //using this year, add 10 more years
            else
            {
                ComboBoxItem itemCombo = (ComboBoxItem)year_combo.Items[year_combo.Items.Count - 1];
                int nextYear = Convert.ToInt32(itemCombo.Content)+1;
                for(int i=0;i<10;i++)
                {
                     itemCombo = new ComboBoxItem()
                    {
                        Content = "" + (nextYear + i)
                    };
                    if (i == 9)
                    {
                        //Again if the last item is added, then register it to RequestBringIntoView event
                        itemCombo.RequestBringIntoView += itemCombo_RequestBringIntoView;
                    }
                    year_combo.Items.Add(itemCombo);
                }
            }
        }
        void itemCombo_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            //Omce an event has been raised by a particular last combobox item, it is important to
            //unregister its RequestBringIntoView event
            ComboBoxItem itemCombo = (ComboBoxItem)sender;
            itemCombo.RequestBringIntoView -= itemCombo_RequestBringIntoView;
            //Populate next 10 years
            PopulateNextTenYears();
        }
