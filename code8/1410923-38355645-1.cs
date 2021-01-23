        <Button IsEnabled="{Binding IsNcwrEnabled}" x:Name="warningButton" Width="40" Height="40" Grid.Column="1"
                Grid.Row="1" Tag="{Binding projectId}" Click="warningButtonClick" 
                Foreground="{StaticResource procedure_app_orange_text }">
             <Button.Background>
                 <ImageBrush ImageSource="Asset/step_ncwr.png"/>
             </Button.Background>
        </Button>
        <Button IsEnabled="{Binding IsCommentEnabled}" x:Name="commentButton" Width="40" Height="40" Grid.Column="2"
                Grid.Row="1"  Tag="{Binding projectId}" Click="CommentButtonClick" 
                Foreground="{StaticResource procedure_app_orange_text }" IsTapEnabled="True">
             <Button.Background>
                 <ImageBrush ImageSource="Asset/step_comment.png"/>
             </Button.Background>
         </Button>
         <Button IsEnabled="{Binding IsImageEnabled}" x:Name="imageButton" Width="40" Height="40" Grid.Column="3"
                 Grid.Row="1"  Tag="{Binding projectId}" Click="ImageButtonClick" 
                 Foreground="{StaticResource procedure_app_orange_text }">
             <Button.Background>
                 <ImageBrush ImageSource="Asset/step_image.png"/>
             </Button.Background>
         </Button>
