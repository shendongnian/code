    private async void openFileNow(string fileName)
        {
            try
            {
                if(fileName.EndsWith(".txt"))
                {
                    //Obviously you'll do something different with an .mp3
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        txtEditBox.Text = await reader.ReadToEndAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Can't open that file.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
