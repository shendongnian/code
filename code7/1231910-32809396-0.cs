        <Border Grid.Row="1" BorderThickness="0,1" BorderBrush="Gray" Grid.RowSpan="2">                
              <RichTextBox x:Name="rtbDocument" ScrollViewer.VerticalScrollBarVisibility="Auto" IsUndoEnabled="False" IsReadOnly="True" BorderThickness="5" IsDocumentEnabled="True" Background="Transparent" Margin="0,34,0,69">
                 <FlowDocument/>
              </RichTextBox>                
         </Border>
    
    Paragraph p = new Paragraph();            
    p.FontSize = 20;
    p.Margin = new Thickness(0, 5, 0, 5);
    p.Inlines.Add(new Run("some gqgb qqj"));
    rtbDocument.Document.Blocks.Add(p);
