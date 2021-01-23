    <xctk:DateTimePicker Value="{Binding todayDate}"></xctk:DateTimePicker>
    
    private DateTime todayDate = DateTime.Today;
            public DateTime todayDate
            {
                get
                {
                    return todayDate
                }
                set
                {
                      todayDate = value;
                 }
              }
