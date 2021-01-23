    <ListView x:Name="LstQuestions" SelectionMode="None" Grid.Row="1" LayoutUpdated="LstQuestions_LayoutUpdated" d:IsLocked="True">
        <ListView.ItemsPanel>
             <ItemsPanelTemplate>
                 <WrapGrid Orientation="Horizontal"/>
             </ItemsPanelTemplate>
        </ListView.ItemsPanel>
    </ListView>
    public Questions()
    {  
        InitializeComponent();
        for(int i=1;i<= 500; i++)
        {
             Button btn = new Button();
             btn.Width = 120;
             btn.Height = 120;
             btn.Click += Btn_Click;
             btn.Content = i;
             LstQuestions.Items.Add(btn);
        }
        LstQuestions.UpdateLayout();
    }
    private void LstQuestions_LayoutUpdated(object sender, object e)
    {
       LstQuestions.ScrollIntoView(LstQuestions.Items[_CurrentQuestionNumber]);
    }
