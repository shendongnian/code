    private async void button4_Click(object sender, EventArgs e)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        MyDbContext context = new MyDbContext();
                        for (int i = 0; i < 10000; i++)
                        {
                            context.Table1.Add(new Table1() { Name = "jon" + i });
                        }
                        await context.SaveChangesAsync();
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
