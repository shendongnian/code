    <DataGridTextColumn Header="Original" SortMemberPath="SortParam">
      <DataGridTextColumn.Binding>
        <MultiBinding Converter="{StaticResource OriginalConverter}">
          <Binding Path="Status.Id" />
          <Binding Path="Original" />
          <Binding Path="Substitution" />
        </MultiBinding>
      </DataGridTextColumn.Binding>
      <DataGridTextColumn.ElementStyle>
        ...
      </DataGridTextColumn.ElementStyle>
    </DataGridTextColumn>
    public int SortParam
    {
        get { return (new OriginalConverter()).Convert(new object[] { Status.Id, Original, Substitution }, typeof(int), null, null); }
    }
