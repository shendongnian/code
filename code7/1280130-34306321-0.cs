    private void btnIncarcaLista_Click(object sender, EventArgs e)
            {            
                mtrials.Add(new trials
                {
                    Tname = textBox9.Text,
                    Item = new List<string>(temp_Item),
                    Duration = new List<string>(temp_Duration)
                });
                temp_Duration.Clear();
                temp_Item.Clear();
            }
