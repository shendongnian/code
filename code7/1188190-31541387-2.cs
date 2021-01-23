     public Visibility SetVisibility
        {
            get
            {
                return delete_flag == 1 ? Visibility.Visible:Visibility.Collapsed;
            }
          
        }
    ....
    <toolkit:MenuItem Header="Delete"
      Visibility="{Binding SetVisibility}" 
      Name="DeleteMenuBtn"
      Click="DeleteMenuBtn_Click"
      CommandParameter="{Binding}" />
