    linesInsTemp.Where(x =>x.StartsWith("#product.") )
                    .ToList()
                    .ForEach(item =>
                   {                      
                        for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
                        {
                            this.checkedListBox2.SetItemChecked(i, true);
                        }
                        var index = this.checkedListBox2.Items.IndexOf(item);
                        if (index >= 0)
                            this.checkedListBox2.SetItemChecked(index, true);
                    });
