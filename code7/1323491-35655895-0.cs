    <Button x:Name="btnOne" Content="Test"  Click="btnOne_Click" />
    <Button x:Name="btnTwo" Content="TestTwo" />
    
    
    public void btnOne_Click(object sender, RoutedEvents e){
    
         btnTwo.Background = Brushes.LightBlue;
         btnOne.BackGround = Brushes.Red;
    }
