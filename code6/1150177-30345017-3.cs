     <ContentPresenter Content="{Binding Path=TestString,UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}">
          <ContentPresenter.ContentTemplate>
             <DataTemplate>
                <StackPanel>
                   <TextBox Text="{Binding Path=., UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>
                </StackPanel>
            </DataTemplate>
         </ContentPresenter.ContentTemplate>
     </ContentPresenter>
