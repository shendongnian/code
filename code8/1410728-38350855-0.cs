    private void saveText_Click(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrEmpty(textResult.Text))
                {
                    saveText.IsEnabled = false;
                    MessageBox.Show("No Text to save!");
                }
                else
                {
    		if(MessageBox.Show("are you sure you want to overwrite the file.", "Alert", MessageBoxButtons.YesNo)==DialogResult.Yes)
    		{
                    saveText.IsEnabled = true;
                    string test = textResult.Text;
                    System.IO.File.WriteAllText(filePathBox.Text, test);
    				}
                }
    
                //fileSaveIcon.Visibility = Visibility.Visible;
                //fileChangedIcon.Visibility = Visibility.Hidden;
    
            }
